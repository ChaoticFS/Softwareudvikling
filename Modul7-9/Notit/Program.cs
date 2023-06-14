using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Notit.Client;
using Notit.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<CommentService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7235/");
});

builder.Services.AddHttpClient<ThreadService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7235/");
});

await builder.Build().RunAsync();
