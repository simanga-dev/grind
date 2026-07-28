using Grind.Domain.Entities;

namespace Grind.Application.Interfaces;

public interface IExerciseService
{
    Task<IEnumerable<Exercise>> GetAllExercisesAsync();
    Task<Exercise?> GetExerciseByIdAsync(string id);
    Task<IEnumerable<Exercise>> GetExercisesByBodyPartAsync(string bodyPart);
}

public interface IProgramService
{
    Task<WorkoutProgram?> GetComebackProgramAsync();
}

public interface IProgressService
{
    Task<UserProgress?> GetProgressAsync(string userId, string programId, int week, string day, string exerciseId);
    Task SaveProgressAsync(UserProgress progress);
    Task<IEnumerable<UserProgress>> GetUserProgressAsync(string userId, string programId);
}
