<script lang="ts">
	import { goto } from '$app/navigation';
	import { page } from '$app/stores';
	import { onMount } from 'svelte';
	import { fade } from 'svelte/transition';
	import { workoutProgram, loadExercises, getExerciseMap, type Exercise } from '$lib/data';
	import { progress } from '$lib/stores/progress';

	let weekIdx = $derived(Number($page.url.searchParams.get('w')) ?? 0);
	let dayIdx = $derived(Number($page.url.searchParams.get('d')) ?? 0);
	let day = $derived(workoutProgram.weeks[weekIdx]?.days[dayIdx]);
	let programWeek = $derived(workoutProgram.weeks[weekIdx]);

	let currentEx = $state(0);
	let exData = $state<Map<string, Exercise>>(new Map());
	let loaded = $state(false);
	let showCelebration = $state(false);

	onMount(async () => {
		exData = await loadExercises();
		loaded = true;
	});

	let touchStartY = 0;

	function handleTouchStart(e: TouchEvent) {
		touchStartY = e.touches[0].clientY;
	}

	function handleTouchEnd(e: TouchEvent) {
		if (!day) return;
		const dy = touchStartY - e.changedTouches[0].clientY;
		if (Math.abs(dy) < 60) return;
		if (dy > 0 && currentEx < day.exercises.length - 1) currentEx++;
		else if (dy < 0 && currentEx > 0) currentEx--;
	}

	function handleWheel(e: WheelEvent) {
		if (!day) return;
		if (Math.abs(e.deltaY) < 30) return;
		if (e.deltaY > 0 && currentEx < day.exercises.length - 1) currentEx++;
		else if (e.deltaY < 0 && currentEx > 0) currentEx--;
	}

	function handleKeyDown(e: KeyboardEvent) {
		if (!day) return;
		if (e.key === 'ArrowDown' && currentEx < day.exercises.length - 1) currentEx++;
		else if (e.key === 'ArrowUp' && currentEx > 0) currentEx--;
	}

	function goBack() {
		goto('/');
	}

	function toggleSet(exIdx: number, setIdx: number, totalSets: number) {
		progress.toggleSet(weekIdx, dayIdx, exIdx, setIdx, totalSets);
	}

	function toggleComplete(exIdx: number, totalSets: number) {
		progress.toggleDone(weekIdx, dayIdx, exIdx, totalSets);
		// auto-advance after completing
		if (day && exIdx < day.exercises.length - 1) {
			setTimeout(() => currentEx++, 300);
		} else if (day) {
			setTimeout(() => {
				if (progress.isDayComplete(weekIdx, dayIdx, day.exercises.length)) {
					showCelebration = true;
				}
			}, 400);
		}
	}

	function getExProgress(exIdx: number, totalSets: number) {
		let p = { sets: new Array(totalSets).fill(false), done: false };
		const key = `w${weekIdx}-d${dayIdx}-e${exIdx}`;
		if (typeof window !== 'undefined') {
			try {
				const stored = localStorage.getItem('grind-progress');
				if (stored) {
					const data = JSON.parse(stored);
					if (data[key]) p = data[key];
				}
			} catch {}
		}
		return p;
	}

	// Computed reactive values
</script>

<svelte:head>
	<title>Week {programWeek?.week ?? ''} · {day?.label ?? ''} — Grind</title>
</svelte:head>

{#if !day}
	<div class="error"><p>Workout not found.</p><button onclick={goBack}>Back</button></div>
{:else}
	<div class="workout" onwheel={handleWheel} onkeydown={handleKeyDown} tabindex="0">


		{#each day.exercises as ex, i}
			{@const exP = getExProgress(i, ex.sets)}
			{@const detail = exData.get(ex.id)}
			{@const allSetsDone = exP.sets.every(Boolean)}
			{@const visible = i === currentEx}
			<div
				class="card"
				class:visible
				style="transform: translateY({(i - currentEx) * 100}%); z-index: {i === currentEx ? 10 : 1};"
				ontouchstart={handleTouchStart}
				ontouchend={handleTouchEnd}
			>
				<!-- Header -->
				<div class="header">
					<button class="back" onclick={goBack}>←</button>
					<div class="pos">
						<span class="counter">{i + 1} / {day.exercises.length}</span>
						<span class="meta">W{programWeek.week} · {day.label}</span>
					</div>
					<div class="spacer"></div>
				</div>

				<!-- Image -->
				<div class="img-wrap">
					{#if detail?.image}
						<img src="/images/{detail.image}" alt={detail.name} />
					{:else if detail}
						<div class="no-img">🏋️</div>
					{:else}
						<div class="no-img">Loading...</div>
					{/if}
				</div>

				<!-- Swipe hint -->
				{#if i === 0 && !exP.done}
					<div class="swipe-hint">↑ swipe up for next</div>
				{/if}

				<!-- Info -->
				<div class="info">
					<h2>{detail?.name ?? `Exercise ${ex.id}`}</h2>
					<div class="tags">
						{#if detail?.target}<span class="tag target">{detail.target}</span>{/if}
						{#if detail?.equipment}<span class="tag">{detail.equipment}</span>{/if}
						{#if detail?.body_part}<span class="tag">{detail.body_part}</span>{/if}
					</div>

					<div class="rx">
						<div class="rx-item"><span class="rx-label">Sets</span><span class="rx-value">{ex.sets}</span></div>
						<div class="rx-item"><span class="rx-label">Reps</span><span class="rx-value">{ex.reps}</span></div>
						<div class="rx-item"><span class="rx-label">Rest</span><span class="rx-value">{ex.rest}</span></div>
					</div>

					{#if detail?.instructions}
						<div class="instructions">{detail.instructions.slice(0, 200)}</div>
					{/if}

					<!-- Set tracker -->
					<div class="sets">
						{#each Array(ex.sets) as _, s}
							<button
								class="set-dot"
								class:done={exP.sets[s]}
								onclick={() => toggleSet(i, s, ex.sets)}
							>{exP.sets[s] ? '✓' : s + 1}</button>
						{/each}
					</div>

					<!-- Complete button -->
					<button
						class="complete-btn"
						class:ready={allSetsDone}
						class:completed={exP.done}
						onclick={() => allSetsDone || exP.done ? toggleComplete(i, ex.sets) : null}
					>
						{#if exP.done}✓ Completed
						{:else if allSetsDone}Mark Complete
						{:else}Complete all {ex.sets} sets
						{/if}
					</button>
				</div>
			</div>
		{/each}
	</div>
{/if}

<!-- Celebration overlay -->
{#if showCelebration}
	<div class="celebration" transition:fade>
		<div class="celeb-card">
			<div class="emoji">🎉</div>
			<h2>Day Complete!</h2>
			<p>You showed up. The grind continues.</p>
			<button onclick={() => { showCelebration = false; goto('/'); }}>Back to Program</button>
		</div>
	</div>
{/if}

<style>
	.workout { position: fixed; inset: 0; background: #0a0a0f; }
	.error { display: flex; height: 100%; align-items: center; justify-content: center; flex-direction: column; gap: 16px; }
	.error button { background: #ff6b6b; border: none; color: #fff; padding: 10px 24px; border-radius: 10px; cursor: pointer; }

	.card { position: absolute; inset: 0; display: flex; flex-direction: column;
		transition: transform .35s cubic-bezier(.32,.72,.32,1); background: #0a0a0f; padding-top: env(safe-area-inset-top); }

	.header { display: flex; align-items: center; justify-content: space-between; padding: 14px 18px; z-index: 10; }
	.back { background: rgba(255,255,255,.08); border: none; color: #fff; width: 38px; height: 38px; border-radius: 50%; font-size: 18px; cursor: pointer; }
	.pos { text-align: center; }
	.counter { font-size: 14px; color: #999; font-weight: 600; display: block; }
	.meta { font-size: 12px; color: #777; }
	.spacer { width: 38px; }

	.img-wrap { flex: 1; display: flex; align-items: center; justify-content: center; padding: 0 24px; min-height: 0; }
	.img-wrap img { max-width: 100%; max-height: 100%; object-fit: contain; border-radius: 20px; background: #fff; }
	.no-img { font-size: 80px; width: 100%; aspect-ratio: 1; max-height: 100%; background: #16161f; border-radius: 20px; display: flex; align-items: center; justify-content: center; }

	.swipe-hint { position: absolute; bottom: 42%; left: 50%; transform: translateX(-50%); color: #555; font-size: 12px;
		animation: bob 2s infinite ease-in-out; pointer-events: none; z-index: 5; }
	@keyframes bob { 0%,100% { transform: translate(-50%,0); } 50% { transform: translate(-50%,-8px); } }

	.info { padding: 14px 22px calc(20px + env(safe-area-inset-bottom)); }
	.info h2 { font-size: 24px; font-weight: 800; margin-bottom: 6px; }
	.tags { display: flex; gap: 6px; flex-wrap: wrap; margin-bottom: 10px; }
	.tag { background: #1e1e2a; border: 1px solid #2d2d3d; border-radius: 999px; padding: 4px 12px; font-size: 12px; color: #ccc; }
	.tag.target { background: rgba(255,107,107,.15); border-color: rgba(255,107,107,.3); color: #ffa8a8; }

	.rx { display: flex; gap: 14px; margin-bottom: 10px; }
	.rx-item { flex: 1; background: #16161f; border: 1px solid #262633; border-radius: 12px; padding: 10px; text-align: center; }
	.rx-label { font-size: 10px; color: #888; text-transform: uppercase; letter-spacing: 1px; display: block; }
	.rx-value { font-size: 18px; font-weight: 800; color: #ffa94d; margin-top: 2px; display: block; }

	.instructions { font-size: 13px; color: #999; line-height: 1.5; max-height: 70px; overflow-y: auto; margin-bottom: 14px; }

	.sets { display: flex; gap: 10px; margin-bottom: 14px; }
	.set-dot { flex: 1; height: 44px; border-radius: 12px; background: #1e1e2a;
		border: 2px solid #2d2d3d; display: flex; align-items: center; justify-content: center;
		font-weight: 700; font-size: 14px; color: #888; cursor: pointer; transition: all .2s; font-family: inherit; }
	.set-dot.done { background: rgba(74,222,128,.15); border-color: #4ade80; color: #4ade80; }

	.complete-btn { width: 100%; padding: 16px; border: none; border-radius: 14px;
		font-size: 17px; font-weight: 800; cursor: pointer; transition: all .2s; font-family: inherit;
		background: #1e1e2a; color: #888; border: 2px solid #2d2d3d; }
	.complete-btn.ready { background: linear-gradient(135deg, #4ade80, #22d3ee); color: #0a0a0f; border-color: transparent; }
	.complete-btn.completed { background: rgba(74,222,128,.15); color: #4ade80; border-color: #4ade80; }

	/* Celebration */
	.celebration { position: fixed; inset: 0; background: rgba(10,10,15,.96); display: flex;
		align-items: center; justify-content: center; z-index: 100; }
	.celeb-card { text-align: center; padding: 30px; }
	.emoji { font-size: 80px; margin-bottom: 20px; }
	.celeb-card h2 { font-size: 28px; font-weight: 800; margin-bottom: 8px;
		background: linear-gradient(135deg, #4ade80, #22d3ee); -webkit-background-clip: text; background-clip: text; color: transparent; }
	.celeb-card p { color: #888; margin-bottom: 30px; }
	.celeb-card button { background: linear-gradient(135deg, #4ade80, #22d3ee); color: #0a0a0f;
		border: none; padding: 16px 40px; border-radius: 14px; font-size: 16px; font-weight: 800; cursor: pointer; font-family: inherit; }
</style>
