import { writable } from 'svelte/store';
import { browser } from '$app/environment';

export interface ExerciseProgress {
	sets: boolean[];
	done: boolean;
}

type ProgressMap = Record<string, ExerciseProgress>;

function loadProgress(): ProgressMap {
	if (!browser) return {};
	try {
		const stored = localStorage.getItem('grind-progress');
		return stored ? JSON.parse(stored) : {};
	} catch {
		return {};
	}
}

function saveProgress(data: ProgressMap) {
	if (!browser) return;
	localStorage.setItem('grind-progress', JSON.stringify(data));
}

function createProgressStore() {
	const { subscribe, set, update } = writable<ProgressMap>(loadProgress());

	return {
		subscribe,
		toggleSet(week: number, dayIdx: number, exIdx: number, setIdx: number, totalSets: number) {
			const key = `w${week}-d${dayIdx}-e${exIdx}`;
			update(data => {
				const entry = data[key] || { sets: new Array(totalSets).fill(false), done: false };
				entry.sets[setIdx] = !entry.sets[setIdx];
				entry.done = entry.sets.every(Boolean);
				data[key] = entry;
				saveProgress(data);
				return { ...data };
			});
		},
		toggleDone(week: number, dayIdx: number, exIdx: number, totalSets: number) {
			const key = `w${week}-d${dayIdx}-e${exIdx}`;
			update(data => {
				const entry = data[key] || { sets: new Array(totalSets).fill(false), done: false };
				entry.done = !entry.done;
				if (entry.done) entry.sets = new Array(totalSets).fill(true);
				else entry.sets = new Array(totalSets).fill(false);
				data[key] = entry;
				saveProgress(data);
				return { ...data };
			});
		},
		getDayProgress(week: number, dayIdx: number, exerciseCount: number): { done: number; total: number; pct: number } {
			let done = 0;
			for (let e = 0; e < exerciseCount; e++) {
				const key = `w${week}-d${dayIdx}-e${e}`;
				const stored = loadProgress();
				if (stored[key]?.done) done++;
			}
			return { done, total: exerciseCount, pct: Math.round(done / exerciseCount * 100) };
		},
		isDayComplete(week: number, dayIdx: number, exerciseCount: number): boolean {
			for (let e = 0; e < exerciseCount; e++) {
				const key = `w${week}-d${dayIdx}-e${e}`;
				if (!loadProgress()[key]?.done) return false;
			}
			return true;
		},
		resetAll() {
			set({});
			saveProgress({});
		}
	};
}

export const progress = createProgressStore();
