using System.Web;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<string> frugter = new List<string>
{
    "�ble", "banan", "p�re", "ananas", "melon"
};

Random rnd = new Random();
int num = rnd.Next();

app.MapGet("/api/frugt", () => frugter); // H�ndter GET-anmodning til "/api/frugt" og returner listen af frugter

app.MapGet("/api/frugt/{id}", (int id) => frugter[id]); // H�ndter GET-anmodning til "/api/frugt/{id}" og returner frugten med den specificerede id

app.MapGet("/api/frugt/random", () => frugter[rnd.Next(frugter.Count)]); // H�ndter GET-anmodning til "/api/frugt/random" og returner en tilf�ldig frugt fra listen

app.MapPost("/api/frugt/", (Frugt frugt) =>
{
    if (frugt == null) // Hvis frugt er null
    {
        throw new BadHttpRequestException("kan ikke finde frugt"); // Kast en undtagelse med en fejlmeddelelse
    }
    if (frugt.name == "" || frugt.name == null) // Hvis frugtens navn er tomt eller null
    {
        throw new BadHttpRequestException("frugt name ikke specificeret"); // Kast en undtagelse med en fejlmeddelelse
    }

    frugter.Add(frugt.name); // Tilf�j frugten til listen

    Console.WriteLine($"Tilf�jet frugt: {frugter.Last()}"); // Udskriv en besked med den senest tilf�jede frugt

    return frugter; // Returner den opdaterede liste af frugter
});

app.Run(); // K�r webapplikationen

record Frugt(string name); // Definer en rekordtype "Frugt" med en enkelt felt: name
