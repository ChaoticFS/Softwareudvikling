var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api/hello/", () => new { Message = "Hello world!" }); // H�ndter GET-anmodning til "/api/hello/" og returner en anonym objekt med en besked

app.MapGet("/api/hello/{name}", (string name) => new { Message = $"Hello {name}!" }); // H�ndter GET-anmodning til "/api/hello/{name}" og returner en anonym objekt med en personaliseret besked baseret p� navnet

app.MapGet("/api/hello/{name}/{age}", (string name, int age) => new { Message = $"Hello {name}! you are {age} years old" }); // H�ndter GET-anmodning til "/api/hello/{name}/{age}" og returner en anonym objekt med en personaliseret besked baseret p� navn og alder

app.Run(); // K�r webapplikationen

