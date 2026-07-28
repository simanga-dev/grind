using Grind.Application.Interfaces;
using Grind.Domain.Entities;

namespace Grind.Infrastructure.Services;

public class ProgramService : IProgramService
{
    private readonly WorkoutProgram _program;

    public ProgramService()
    {
        _program = CreateComebackProgram();
    }

    public Task<WorkoutProgram?> GetComebackProgramAsync() => Task.FromResult<WorkoutProgram?>(_program);

    private static WorkoutProgram CreateComebackProgram() => new()
    {
        Id = "comeback-4week",
        Name = "Comeback Protocol",
        Description = "4-week return to training after 3-4 months off",
        Weeks =
        [
            new WorkoutWeek
            {
                WeekNumber = 1,
                Focus = "Rebuild Base - Full Body",
                Days =
                [
                    new WorkoutDay
                    {
                        Label = "A",
                        Name = "Push + Legs",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0662", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0289", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0543", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0549", Sets = 3, Reps = "10-15", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0464", Sets = 3, Reps = "30-60s", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "B",
                        Name = "Pull + Core",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0027", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0670", Sets = 3, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "1009", Sets = 3, Reps = "12-15", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0320", Sets = 3, Reps = "8/side", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0260", Sets = 3, Reps = "6/side", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "C",
                        Name = "Full Body Integration",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0773", Sets = 3, Reps = "10-15", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0493", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0302", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0731", Sets = 3, Reps = "20-45s/side", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0630", Sets = 3, Reps = "20 total", Rest = "60s" }
                        ]
                    }
                ]
            },
            new WorkoutWeek
            {
                WeekNumber = 2,
                Focus = "Add Volume - Full Body",
                Days =
                [
                    new WorkoutDay
                    {
                        Label = "A",
                        Name = "Push + Legs",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0662", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0289", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0543", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0549", Sets = 4, Reps = "10-15", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0464", Sets = 3, Reps = "45-60s", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "B",
                        Name = "Pull + Core",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0027", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0670", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "1009", Sets = 4, Reps = "12-15", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0320", Sets = 4, Reps = "8/side", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0260", Sets = 4, Reps = "6/side", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "C",
                        Name = "Full Body Integration",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0773", Sets = 4, Reps = "10-15", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0493", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0302", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0731", Sets = 4, Reps = "30-45s/side", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0630", Sets = 4, Reps = "30 total", Rest = "60s" }
                        ]
                    }
                ]
            },
            new WorkoutWeek
            {
                WeekNumber = 3,
                Focus = "Upper/Lower Split",
                Days =
                [
                    new WorkoutDay
                    {
                        Label = "Upper A",
                        Name = "Horizontal Push/Pull",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0289", Sets = 4, Reps = "6-10", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0027", Sets = 4, Reps = "6-10", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0400", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0160", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0401", Sets = 3, Reps = "10-15", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0201", Sets = 3, Reps = "8-12", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Lower A",
                        Name = "Squat Pattern + Core",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0102", Sets = 4, Reps = "6-10", Rest = "2-3min" },
                            new ProgramExercise { ExerciseId = "0302", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0739", Sets = 3, Reps = "10-15", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0167", Sets = 4, Reps = "12-15", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0464", Sets = 3, Reps = "8-12", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Upper B",
                        Name = "Vertical Push/Pull",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0670", Sets = 4, Reps = "4-8", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0400", Sets = 4, Reps = "6-10", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0326", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0700", Sets = 3, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0401", Sets = 3, Reps = "10-12", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0201", Sets = 3, Reps = "10-12", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Lower B",
                        Name = "Hinge Pattern + Calves",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0302", Sets = 4, Reps = "5-8", Rest = "2-3min" },
                            new ProgramExercise { ExerciseId = "0543", Sets = 3, Reps = "8/leg", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0739", Sets = 3, Reps = "10-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0167", Sets = 4, Reps = "10-12", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0630", Sets = 3, Reps = "20 total", Rest = "60s" }
                        ]
                    }
                ]
            },
            new WorkoutWeek
            {
                WeekNumber = 4,
                Focus = "Increase Intensity",
                Days =
                [
                    new WorkoutDay
                    {
                        Label = "Upper A",
                        Name = "Horizontal Push/Pull",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0289", Sets = 5, Reps = "5-8", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0027", Sets = 5, Reps = "5-8", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0400", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0160", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0401", Sets = 3, Reps = "8-12", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0201", Sets = 3, Reps = "6-10", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Lower A",
                        Name = "Squat Pattern + Core",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0102", Sets = 5, Reps = "5-8", Rest = "2-3min" },
                            new ProgramExercise { ExerciseId = "0302", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0739", Sets = 4, Reps = "8-12", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0167", Sets = 5, Reps = "10-12", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0464", Sets = 4, Reps = "6-10", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Upper B",
                        Name = "Vertical Push/Pull",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0670", Sets = 5, Reps = "3-6", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0400", Sets = 5, Reps = "5-8", Rest = "2min" },
                            new ProgramExercise { ExerciseId = "0326", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0700", Sets = 4, Reps = "6-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0401", Sets = 3, Reps = "8-10", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0201", Sets = 3, Reps = "8-10", Rest = "60s" }
                        ]
                    },
                    new WorkoutDay
                    {
                        Label = "Lower B",
                        Name = "Hinge Pattern + Calves",
                        Exercises =
                        [
                            new ProgramExercise { ExerciseId = "0302", Sets = 5, Reps = "3-6", Rest = "2-3min" },
                            new ProgramExercise { ExerciseId = "0543", Sets = 4, Reps = "6-8/leg", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0739", Sets = 4, Reps = "8-10", Rest = "90s" },
                            new ProgramExercise { ExerciseId = "0167", Sets = 5, Reps = "8-10", Rest = "60s" },
                            new ProgramExercise { ExerciseId = "0630", Sets = 4, Reps = "30 total", Rest = "60s" }
                        ]
                    }
                ]
            }
        ]
    };
}
