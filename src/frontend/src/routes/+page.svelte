<script lang="ts">
	import { goto } from '$app/navigation';
	import { workoutProgram } from '$lib/data';
	import { progress } from '$lib/stores/progress';

	let overallPct = $derived.by(() => {
		let total = 0, done = 0;
		workoutProgram.weeks.forEach((w, wi) => {
			w.days.forEach((d, di) => {
				const p = progress.getDayProgress(wi, di, d.exercises.length);
				total += p.total;
				done += p.done;
			});
		});
		return total ? Math.round(done / total * 100) : 0;
	});

	function openDay(weekIdx: number, dayIdx: number) {
		goto(`/workout?w=${weekIdx}&d=${dayIdx}`);
	}

	function resetAll() {
		if (typeof window !== 'undefined' && confirm('Reset all progress? This cannot be undone.')) {
			progress.resetAll();
		}
	}
</script>

<svelte:head>
	<title>Grind – Workout Tracker</title>
</svelte:head>

<div class="home">
	<h1>Grind 💪</h1>
	<p class="sub">4-week return to training · TikTok-style</p>

	<div class="overall">
		<span class="label">Overall Progress</span>
		<span class="big">{overallPct}%</span>
		<div class="bar"><div class="fill" style="width:{overallPct}%"></div></div>
	</div>

	{#each workoutProgram.weeks as week, wi}
		<div class="week-card">
			<h3>Week {week.week}</h3>
			<p class="focus">{week.focus}</p>
			{#each week.days as day, di}
				{@const p = progress.getDayProgress(wi, di, day.exercises.length)}
				{@const done = p.pct === 100}
				<button class="day-btn" class:done onclick={() => openDay(wi, di)}>
					<div class="day-left">
						<span class="day-label">{day.label}</span>
						<span class="day-name">{day.name}</span>
					</div>
					<div class="day-right">
						<span class="ex-count">{p.done}/{p.total}</span>
						{#if done}
							<span class="check">✓</span>
						{:else}
							<div class="ring" style="--pct:{p.pct}">
								<svg viewBox="0 0 36 36"><circle class="bg" cx="18" cy="18" r="14" fill="none" stroke-width="3"/><circle class="fg" cx="18" cy="18" r="14" fill="none" stroke-width="3"/></svg>
								<span class="pct">{p.pct}</span>
							</div>
						{/if}
					</div>
				</button>
			{/each}
		</div>
	{/each}

	<button class="reset" onclick={resetAll}>Reset all progress</button>
</div>

<style>
	.home { height: 100%; overflow-y: auto; padding: 20px 20px 100px; }
	h1 { font-size: 32px; font-weight: 800; margin: 10px 0 4px;
		background: linear-gradient(135deg, #ff6b6b, #ffa94d);
		-webkit-background-clip: text; background-clip: text; color: transparent; }
	.sub { color: #888; font-size: 14px; margin-bottom: 24px; }
	.overall { background: linear-gradient(135deg, #1a1a2e, #16161f); border: 1px solid #2d2d3d;
		border-radius: 16px; padding: 18px; margin-bottom: 20px; }
	.label { font-size: 12px; color: #888; text-transform: uppercase; letter-spacing: 1px; display: block; }
	.big { font-size: 28px; font-weight: 800; color: #4ade80; }
	.bar { height: 8px; background: #262633; border-radius: 4px; margin-top: 10px; }
	.fill { height: 100%; background: linear-gradient(90deg, #4ade80, #22d3ee); border-radius: 4px; transition: width .4s; }

	.week-card { background: #16161f; border: 1px solid #262633; border-radius: 16px; padding: 18px; margin-bottom: 14px; }
	.week-card h3 { font-size: 13px; text-transform: uppercase; letter-spacing: 1.5px; color: #ffa94d; margin-bottom: 4px; }
	.week-card .focus { font-size: 17px; font-weight: 600; margin-bottom: 12px; }

	.day-btn { display: flex; align-items: center; justify-content: space-between; width: 100%;
		background: #1e1e2a; border: 1px solid #2d2d3d; border-radius: 12px; padding: 14px 16px;
		margin-bottom: 8px; color: #fff; font: inherit; cursor: pointer; transition: transform .15s; text-align: left; }
	.day-btn:active { transform: scale(.97); background: #262638; }
	.day-left { display: flex; flex-direction: column; gap: 2px; }
	.day-label { font-weight: 700; font-size: 16px; }
	.day-name { color: #999; font-size: 13px; }
	.day-right { display: flex; align-items: center; gap: 10px; }
	.ex-count { font-size: 12px; color: #777; }
	.check { color: #4ade80; font-size: 18px; }

	.ring { width: 36px; height: 36px; position: relative; }
	.ring svg { transform: rotate(-90deg); width: 100%; height: 100%; }
	.bg { stroke: #2d2d3d; }
	.fg { stroke: #4ade80; stroke-linecap: round; stroke-dasharray: 87.96; stroke-dashoffset: calc(87.96 * (1 - var(--pct) / 100)); }
	.pct { position: absolute; inset: 0; display: flex; align-items: center; justify-content: center; font-size: 9px; font-weight: 700; }
	.day-btn.done .day-label { color: #4ade80; }

	.reset { margin-top: 20px; width: 100%; background: none; border: 1px solid #3d2d2d;
		color: #ff6b6b; border-radius: 10px; padding: 12px; font-size: 13px; cursor: pointer; }
</style>
