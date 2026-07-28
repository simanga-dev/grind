using Grind.Application.Interfaces;
using Grind.Domain.Entities;
using System.Text.Json;

namespace Grind.Infrastructure.Services;

public class ExerciseService : IExerciseService
{
    private readonly List<Exercise> _exercises;

    public ExerciseService()
    {
        var jsonPath = Path.Combine(AppContext.BaseDirectory, "Data", "exercises.json");
        if (File.Exists(jsonPath))
        {
            var json = File.ReadAllText(jsonPath);
            var data = JsonSerializer.Deserialize<List<ExerciseJson>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            _exercises = data?.Select(MapToExercise).ToList() ?? [];
        }
        else
        {
            _exercises = [];
        }
    }

    public Task<IEnumerable<Exercise>> GetAllExercisesAsync() => Task.FromResult(_exercises.AsEnumerable());

    public Task<Exercise?> GetExerciseByIdAsync(string id) =>
        Task.FromResult(_exercises.FirstOrDefault(e => e.Id == id));

    public Task<IEnumerable<Exercise>> GetExercisesByBodyPartAsync(string bodyPart) =>
        Task.FromResult(_exercises.Where(e => e.BodyPart.Equals(bodyPart, StringComparison.OrdinalIgnoreCase)));

    private static Exercise MapToExercise(ExerciseJson json) => new()
    {
        Id = json.Id ?? "",
        Name = json.Name ?? "",
        BodyPart = json.BodyPart ?? "",
        Equipment = json.Equipment ?? "",
        Target = json.Target ?? "",
        SecondaryMuscles = json.SecondaryMuscles ?? [],
        Instructions = json.Instructions?.En ?? "",
        ImageUrl = json.Image ?? "",
        GifUrl = json.GifUrl ?? ""
    };

    private class ExerciseJson
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? BodyPart { get; set; }
        public string? Equipment { get; set; }
        public string? Target { get; set; }
        public List<string>? SecondaryMuscles { get; set; }
        public InstructionJson? Instructions { get; set; }
        public string? Image { get; set; }
        public string? GifUrl { get; set; }
    }

    private class InstructionJson
    {
        public string? En { get; set; }
    }
}
