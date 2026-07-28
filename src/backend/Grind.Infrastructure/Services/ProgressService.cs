using Grind.Application.Interfaces;
using Grind.Domain.Entities;
using System.Collections.Concurrent;

namespace Grind.Infrastructure.Services;

public class ProgressService : IProgressService
{
    private readonly ConcurrentDictionary<string, UserProgress> _progress = new();

    public Task<UserProgress?> GetProgressAsync(string userId, string programId, int week, string day, string exerciseId)
    {
        var key = GetKey(userId, programId, week, day, exerciseId);
        _progress.TryGetValue(key, out var progress);
        return Task.FromResult(progress);
    }

    public Task SaveProgressAsync(UserProgress progress)
    {
        progress.UpdatedAt = DateTime.UtcNow;
        var key = GetKey(progress.UserId, progress.ProgramId, progress.WeekNumber, progress.DayLabel, progress.ExerciseId);
        _progress[key] = progress;
        return Task.CompletedTask;
    }

    public Task<IEnumerable<UserProgress>> GetUserProgressAsync(string userId, string programId)
    {
        var result = _progress.Values
            .Where(p => p.UserId == userId && p.ProgramId == programId)
            .AsEnumerable();
        return Task.FromResult(result);
    }

    private static string GetKey(string userId, string programId, int week, string day, string exerciseId) =>
        $"{userId}:{programId}:{week}:{day}:{exerciseId}";
}
