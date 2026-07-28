// Exercise and program data — loaded from the exercises-dataset
export interface Exercise {
	id: string;
	name: string;
	body_part: string;
	equipment: string;
	target: string;
	secondary_muscles: string[];
	instructions: string;
	image: string;
	gif_url: string;
}

export interface ProgramExercise {
	id: string;
	sets: number;
	reps: string;
	rest: string;
}

export interface WorkoutDay {
	label: string;
	name: string;
	exercises: ProgramExercise[];
}

export interface WorkoutWeek {
	week: number;
	focus: string;
	days: WorkoutDay[];
}

export interface WorkoutProgram {
	name: string;
	description: string;
	weeks: WorkoutWeek[];
}

// 4-week comeback program
export const workoutProgram: WorkoutProgram = {
	name: 'Comeback Protocol',
	description: '4-week return to training after 3-4 months off',
	weeks: [
		{
			week: 1, focus: 'Rebuild Base – Full Body',
			days: [
				{ label: 'A', name: 'Push + Legs', exercises: [
					{ id: '0662', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0289', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0543', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0549', sets: 3, reps: '10-15', rest: '90s' },
					{ id: '0464', sets: 3, reps: '30-60s', rest: '60s' }
				]},
				{ label: 'B', name: 'Pull + Core', exercises: [
					{ id: '0027', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0670', sets: 3, reps: '6-10', rest: '90s' },
					{ id: '1009', sets: 3, reps: '12-15', rest: '60s' },
					{ id: '0320', sets: 3, reps: '8/side', rest: '60s' },
					{ id: '0260', sets: 3, reps: '6/side', rest: '60s' }
				]},
				{ label: 'C', name: 'Full Body', exercises: [
					{ id: '0773', sets: 3, reps: '10-15', rest: '90s' },
					{ id: '0493', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0302', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0731', sets: 3, reps: '20-45s/side', rest: '60s' },
					{ id: '0630', sets: 3, reps: '20 total', rest: '60s' }
				]}
			]
		},
		{
			week: 2, focus: 'Add Volume – Full Body',
			days: [
				{ label: 'A', name: 'Push + Legs', exercises: [
					{ id: '0662', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0289', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0543', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0549', sets: 4, reps: '10-15', rest: '90s' },
					{ id: '0464', sets: 3, reps: '45-60s', rest: '60s' }
				]},
				{ label: 'B', name: 'Pull + Core', exercises: [
					{ id: '0027', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0670', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '1009', sets: 4, reps: '12-15', rest: '60s' },
					{ id: '0320', sets: 4, reps: '8/side', rest: '60s' },
					{ id: '0260', sets: 4, reps: '6/side', rest: '60s' }
				]},
				{ label: 'C', name: 'Full Body', exercises: [
					{ id: '0773', sets: 4, reps: '10-15', rest: '90s' },
					{ id: '0493', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0302', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0731', sets: 4, reps: '30-45s/side', rest: '60s' },
					{ id: '0630', sets: 4, reps: '30 total', rest: '60s' }
				]}
			]
		},
		{
			week: 3, focus: 'Upper/Lower Split',
			days: [
				{ label: 'Upper A', name: 'Horizontal Push/Pull', exercises: [
					{ id: '0289', sets: 4, reps: '6-10', rest: '2min' },
					{ id: '0027', sets: 4, reps: '6-10', rest: '2min' },
					{ id: '0400', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0160', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0401', sets: 3, reps: '10-15', rest: '60s' },
					{ id: '0201', sets: 3, reps: '8-12', rest: '60s' }
				]},
				{ label: 'Lower A', name: 'Squat Pattern + Core', exercises: [
					{ id: '0102', sets: 4, reps: '6-10', rest: '2-3min' },
					{ id: '0302', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0739', sets: 3, reps: '10-15', rest: '90s' },
					{ id: '0167', sets: 4, reps: '12-15', rest: '60s' },
					{ id: '0464', sets: 3, reps: '8-12', rest: '60s' }
				]},
				{ label: 'Upper B', name: 'Vertical Push/Pull', exercises: [
					{ id: '0670', sets: 4, reps: '4-8', rest: '2min' },
					{ id: '0400', sets: 4, reps: '6-10', rest: '2min' },
					{ id: '0326', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0700', sets: 3, reps: '8-12', rest: '90s' },
					{ id: '0401', sets: 3, reps: '10-12', rest: '60s' },
					{ id: '0201', sets: 3, reps: '10-12', rest: '60s' }
				]},
				{ label: 'Lower B', name: 'Hinge Pattern + Calves', exercises: [
					{ id: '0302', sets: 4, reps: '5-8', rest: '2-3min' },
					{ id: '0543', sets: 3, reps: '8/leg', rest: '90s' },
					{ id: '0739', sets: 3, reps: '10-12', rest: '90s' },
					{ id: '0167', sets: 4, reps: '10-12', rest: '60s' },
					{ id: '0630', sets: 3, reps: '20 total', rest: '60s' }
				]}
			]
		},
		{
			week: 4, focus: 'Increase Intensity',
			days: [
				{ label: 'Upper A', name: 'Horizontal Push/Pull', exercises: [
					{ id: '0289', sets: 5, reps: '5-8', rest: '2min' },
					{ id: '0027', sets: 5, reps: '5-8', rest: '2min' },
					{ id: '0400', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '0160', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '0401', sets: 3, reps: '8-12', rest: '60s' },
					{ id: '0201', sets: 3, reps: '6-10', rest: '60s' }
				]},
				{ label: 'Lower A', name: 'Squat Pattern + Core', exercises: [
					{ id: '0102', sets: 5, reps: '5-8', rest: '2-3min' },
					{ id: '0302', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '0739', sets: 4, reps: '8-12', rest: '90s' },
					{ id: '0167', sets: 5, reps: '10-12', rest: '60s' },
					{ id: '0464', sets: 4, reps: '6-10', rest: '60s' }
				]},
				{ label: 'Upper B', name: 'Vertical Push/Pull', exercises: [
					{ id: '0670', sets: 5, reps: '3-6', rest: '2min' },
					{ id: '0400', sets: 5, reps: '5-8', rest: '2min' },
					{ id: '0326', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '0700', sets: 4, reps: '6-10', rest: '90s' },
					{ id: '0401', sets: 3, reps: '8-10', rest: '60s' },
					{ id: '0201', sets: 3, reps: '8-10', rest: '60s' }
				]},
				{ label: 'Lower B', name: 'Hinge Pattern + Calves', exercises: [
					{ id: '0302', sets: 5, reps: '3-6', rest: '2-3min' },
					{ id: '0543', sets: 4, reps: '6-8/leg', rest: '90s' },
					{ id: '0739', sets: 4, reps: '8-10', rest: '90s' },
					{ id: '0167', sets: 5, reps: '8-10', rest: '60s' },
					{ id: '0630', sets: 4, reps: '30 total', rest: '60s' }
				]}
			]
		}
	]
};

// Map of exercise id -> details (loaded async from API or bundled JSON)
let exercisesMap: Map<string, Exercise> = new Map();

export async function loadExercises(): Promise<Map<string, Exercise>> {
	if (exercisesMap.size > 0) return exercisesMap;

	try {
		const res = await fetch('/api/exercises');
		const data: Exercise[] = await res.json();
		for (const ex of data) {
			exercisesMap.set(ex.id, ex);
		}
	} catch {
		// Fallback: try bundled JSON
		try {
			const res = await fetch('/data/exercises.json');
			const data = await res.json();
			for (const ex of data) {
				exercisesMap.set(ex.id, {
					id: ex.id || '',
					name: ex.name || '',
					body_part: ex.body_part || '',
					equipment: ex.equipment || '',
					target: ex.target || '',
					secondary_muscles: ex.secondary_muscles || [],
					instructions: ex.instructions?.en || '',
					image: ex.image || '',
					gif_url: ex.gif_url || ''
				});
			}
		} catch {
			console.warn('Could not load exercises');
		}
	}
	return exercisesMap;
}

export function getExerciseMap(): Map<string, Exercise> {
	return exercisesMap;
}
