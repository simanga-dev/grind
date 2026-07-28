using Grind.Application.Interfaces;
using Grind.Domain.Entities;
using Grind.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<IExerciseService, ExerciseService>();
builder.Services.AddSingleton<IProgramService, ProgramService>();
builder.Services.AddSingleton<IProgressService, ProgressService>();
builder.Services.AddOpenApi();

// CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

// API Endpoints
var api = app.MapGroup("/api");

// Exercises
api.MapGet("/exercises", async (IExerciseService svc) =>
    Results.Ok(await svc.GetAllExercisesAsync()));

api.MapGet("/exercises/{id}", async (string id, IExerciseService svc) =>
{
    var exercise = await svc.GetExerciseByIdAsync(id);
    return exercise is not null ? Results.Ok(exercise) : Results.NotFound();
});

api.MapGet("/exercises/bodypart/{bodyPart}", async (string bodyPart, IExerciseService svc) =>
    Results.Ok(await svc.GetExercisesByBodyPartAsync(bodyPart)));

// Program
api.MapGet("/programs/comeback", async (IProgramService svc) =>
{
    var program = await svc.GetComebackProgramAsync();
    return program is not null ? Results.Ok(program) : Results.NotFound();
});

// Progress
api.MapGet("/progress/{userId}/{programId}", async (string userId, string programId, IProgressService svc) =>
    Results.Ok(await svc.GetUserProgressAsync(userId, programId)));

api.MapGet("/progress/{userId}/{programId}/{week}/{day}/{exerciseId}", async (
    string userId, string programId, int week, string day, string exerciseId, IProgressService svc) =>
{
    var progress = await svc.GetProgressAsync(userId, programId, week, day, exerciseId);
    return progress is not null ? Results.Ok(progress) : Results.NotFound();
});

api.MapPost("/progress", async (UserProgress progress, IProgressService svc) =>
{
    await svc.SaveProgressAsync(progress);
    return Results.Ok(progress);
});

// Health check
app.MapGet("/health", () => Results.Ok(new { status = "healthy", timestamp = DateTime.UtcNow }));

app.Run();
