namespace Grind.Domain.Entities;

public class Exercise
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string BodyPart { get; set; } = string.Empty;
    public string Equipment { get; set; } = string.Empty;
    public string Target { get; set; } = string.Empty;
    public List<string> SecondaryMuscles { get; set; } = [];
    public string Instructions { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string GifUrl { get; set; } = string.Empty;
}

public class WorkoutProgram
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<WorkoutWeek> Weeks { get; set; } = [];
}

public class WorkoutWeek
{
    public int WeekNumber { get; set; }
    public string Focus { get; set; } = string.Empty;
    public List<WorkoutDay> Days { get; set; } = [];
}

public class WorkoutDay
{
    public string Label { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<ProgramExercise> Exercises { get; set; } = [];
}

public class ProgramExercise
{
    public string ExerciseId { get; set; } = string.Empty;
    public int Sets { get; set; }
    public string Reps { get; set; } = string.Empty;
    public string Rest { get; set; } = string.Empty;
}

public class UserProgress
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string ProgramId { get; set; } = string.Empty;
    public int WeekNumber { get; set; }
    public string DayLabel { get; set; } = string.Empty;
    public string ExerciseId { get; set; } = string.Empty;
    public List<bool> CompletedSets { get; set; } = [];
    public bool IsCompleted { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
