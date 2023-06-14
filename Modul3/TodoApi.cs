var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()  // Tillad enhver kilde (origin)
               .AllowAnyHeader()  // Tillad enhver header
               .AllowAnyMethod(); // Tillad enhver HTTP-metode
    });
});

var app = builder.Build();
app.UseCors(AllowCors); // Anvend CORS-policyen på appen

List<Task> tasks = new List<Task>{
    new Task(1, "handle ind", false),
    new Task(2, "vaske op", false),
    new Task(3, "lave mad", false)
};

app.MapGet("/api/tasks", () => tasks); // Håndter GET-anmodning til "/api/tasks" og returner listen af opgaver (tasks)
app.MapGet("/api/tasks/{id}", (int id) => tasks.Find(x => x.id == id)); // Håndter GET-anmodning til "/api/tasks/{id}" og returner opgaven med den specificerede id

app.MapPost("/api/tasks", (Task task) =>
{
    int max = tasks.Max(x => x.id);
    tasks.Add(new Task(++max, task.text, task.done)); // Tilføj en ny opgave til listen med en automatisk genereret id
    return tasks.ToArray(); // Returner den opdaterede liste af opgaver
});

app.MapPut("/api/tasks/{id}", (int id, Task task) =>
{
    tasks[tasks.FindIndex(x => x.id == id)] = (new Task(id, task.text, task.done)); // Opdater en eksisterende opgave i listen med den specificerede id
    return tasks.ToArray(); // Returner den opdaterede liste af opgaver
});

app.MapDelete("/api/tasks/{id}", (int id) =>
{
    tasks.Remove(tasks.Find(x => x.id == id)); // Fjern en opgave fra listen med den specificerede id
    return tasks.ToArray(); // Returner den opdaterede liste af opgaver
});

app.Run(); // Kør webapplikationen

record Task(int id, string text, bool done); // Definer en rekordtype "Task" med tre felter: id, text og done
