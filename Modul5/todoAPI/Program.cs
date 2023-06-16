using Microsoft.EntityFrameworkCore;
using Models;

/// builder+app setup

var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<TaskContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TaskContextSQLite")));

var app = builder.Build();
app.UseCors(AllowCors);

/// code
/*
using (var db = new TaskContext())
{
    
    db.Users.Add(new User("Asger", "asn@mail.dk"));
    db.SaveChanges();
    
    
    db.Tasks.Add(new TodoTask("handle ind", "hverdag", db.Users.First(), false));
    db.Tasks.Add(new TodoTask("vaske op", "hverdag", db.Users.First(), false));
    db.Tasks.Add(new TodoTask("lave mad", "hverdag", db.Users.First(), false));
    db.SaveChanges();
    
}
*/

app.MapGet("/api/tasks", (TaskContext db) => db.Tasks.Include(t => t.User));//.OrderBy(b => b.TodoTaskId).ToList<TodoTask>());

app.MapGet("/api/tasks/{id}", (long id, TaskContext db) => db.Tasks.Where(x => x.TodoTaskId == id).Include(t => t.User).FirstOrDefault<TodoTask>());

app.MapPost("/api/tasks", (TodoTask task, TaskContext db) =>
{
    db.Tasks.Add(new TodoTask(task.Text, task.Category, db.Users.First(), task.Done));
    db.SaveChanges();
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

app.MapPut("/api/tasks/{id}", (int id, TodoTask task, TaskContext db) =>
{
    var entry = db.Tasks.Find((long)id); //var entry = db.Tasks.Where(x => x.TodoTaskId == id).FirstOrDefault<TodoTask>();
    if (entry != null)
    {
        entry.Text = task.Text;
        entry.Category = task.Category;
        entry.Done = task.Done;
        //db.Tasks.Update(task);
        db.SaveChanges();
    }
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

app.MapDelete("/api/tasks/{id}", (int id, TaskContext db) =>
{
    var entry = db.Tasks.Find((long)id); //var entry = db.Tasks.Where(x => x.TodoTaskId == id).FirstOrDefault<TodoTask>();
    if (entry != null)
    {
        db.Tasks.Remove(entry);
        db.SaveChanges();
    }
    return db.Tasks.OrderBy(b => b.TodoTaskId).Include(t => t.User).ToList<TodoTask>();
});

app.Run();