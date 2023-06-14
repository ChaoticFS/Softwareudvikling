using Microsoft.EntityFrameworkCore;
using Notit.API.Controllers;
using Notit.API.Models;
using Notit.Shared.Models;
using Thread = Notit.Shared.Models.Thread;

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

builder.Services.AddDbContext<NotitContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ContextSQLite")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<CommentController>();
builder.Services.AddScoped<ThreadController>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var threadService = scope.ServiceProvider.GetRequiredService<ThreadController>();
    if (!threadService.IsSeeded())
    {
        Console.WriteLine("Seeding data");

        Thread exampleThread = new Thread("Test", "Magnus");
        threadService.Post(exampleThread);

        var commentService = scope.ServiceProvider.GetRequiredService<CommentController>();
        Comment exampleComment = new Comment("Kommentar placeholder", "Magnus");
        exampleComment.Thread = exampleThread;
        commentService.Post(exampleComment);

        Console.WriteLine(exampleThread);
        Console.WriteLine(exampleComment);
    }
}

app.UseHttpsRedirection();
app.UseCors(AllowCors);

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
