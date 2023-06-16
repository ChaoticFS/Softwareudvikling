using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
/// Opretter en builder til oprettelse af en webapplikation.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
// Tilføjer CORS-politik for at tillade anmodninger fra alle kilder.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilføjer DbContext TaskContext til Dependency Injection-containeren.
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

var app = builder.Build();
app.UseCors(AllowCors);

/// <code>
/// Her kan der indsættes kode til at oprette og gemme testdata i databasen.
/// </code>

// Mapper GET-forespørgsler til "/api/tasks" til en handling, der returnerer alle opgaver med tilhørende bruger.
app.MapGet("/api/tasks", (TaskContext db) => db.Tasks.Include(t => t.User));

// Mapper GET-forespørgsler til "/api/tasks/{id}" til en handling, der returnerer en specifik opgave med tilhørende bruger baseret på id.
app.MapGet("/api/tasks/{id}", (long id, TaskContext db) => db.Tasks.Where(x => x.TodoTaskId == id).Include(t => t.User).FirstOrDefault<TodoTask>());

// Mapper POST-forespørgsler til "/api/tasks" til en handling, der opretter en ny opgave med tilhørende bruger og gemmer den i databasen.
app.MapPost("/api/tasks", (TodoTask task, TaskContext db) =>
{
    db.Tasks.Add(new TodoTask(task.Text, task.Category, db.Users.First(), task.Done));
    db.SaveChanges();
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

// Mapper PUT-forespørgsler til "/api/tasks/{id}" til en handling, der opdaterer en eksisterende opgave med tilhørende bruger baseret på id.
app.MapPut("/api/tasks/{id}", (int id, TodoTask task, TaskContext db) =>
{
    var entry = db.Tasks.Find((long)id);
    if (entry != null)
    {
        entry.Text = task.Text;
        entry.Category = task.Category;
        entry.Done = task.Done;
        db.SaveChanges();
    }
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

// Mapper DELETE-forespørgsler til "/api/tasks/{id}" til en handling, der sletter en eksisterende opgave med tilhørende bruger baseret på id.
app.MapDelete("/api/tasks/{id}", (int id, TaskContext db) =>
{
    var entry = db.Tasks.Find((long)id);
    if (entry != null)
    {
        db.Tasks.Remove(entry);
        db.SaveChanges();
    }
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

// Starter webapplikationen
app.Run();
