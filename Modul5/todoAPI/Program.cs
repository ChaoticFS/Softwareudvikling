using Microsoft.EntityFrameworkCore;
using Models;

/// <summary>
/// Opretter en builder til oprettelse af en webapplikation.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
// Tilf�jer CORS-politik for at tillade anmodninger fra alle kilder.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Tilf�jer DbContext TaskContext til Dependency Injection-containeren.
builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

var app = builder.Build();
app.UseCors(AllowCors);

/// <code>
/// Her kan der inds�ttes kode til at oprette og gemme testdata i databasen.
/// </code>

// Mapper GET-foresp�rgsler til "/api/tasks" til en handling, der returnerer alle opgaver med tilh�rende bruger.
app.MapGet("/api/tasks", (TaskContext db) => db.Tasks.Include(t => t.User));

// Mapper GET-foresp�rgsler til "/api/tasks/{id}" til en handling, der returnerer en specifik opgave med tilh�rende bruger baseret p� id.
app.MapGet("/api/tasks/{id}", (long id, TaskContext db) => db.Tasks.Where(x => x.TodoTaskId == id).Include(t => t.User).FirstOrDefault<TodoTask>());

// Mapper POST-foresp�rgsler til "/api/tasks" til en handling, der opretter en ny opgave med tilh�rende bruger og gemmer den i databasen.
app.MapPost("/api/tasks", (TodoTask task, TaskContext db) =>
{
    db.Tasks.Add(new TodoTask(task.Text, task.Category, db.Users.First(), task.Done));
    db.SaveChanges();
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

// Mapper PUT-foresp�rgsler til "/api/tasks/{id}" til en handling, der opdaterer en eksisterende opgave med tilh�rende bruger baseret p� id.
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

// Mapper DELETE-foresp�rgsler til "/api/tasks/{id}" til en handling, der sletter en eksisterende opgave med tilh�rende bruger baseret p� id.
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
