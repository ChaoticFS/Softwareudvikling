var builder = WebApplication.CreateBuilder(args);

// Konfigurer CORS-policy med navnet "_AllowCors"
var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder => {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

// Liste over spørgsmål
List<Question> questions = new List<Question>{
    new Question(1,"Which material is most dense?",new string[]{"Silver","Styrofoam","Butter","Gold"},3),
    new Question(2,"Which state in the United States is largest by area?",new string[]{"Alaska","California","Texas","Hawaii"},0),
    new Question(3,"What is Aurora Borealis commonly known as?",new string[]{"Fairy Dust","Northern Lights","Book of ages","Solar Eclipse"},1)
};

// Endpoint til at hente alle spørgsmål
app.MapGet("/api/quiz/", () => {
    return questions.Select(x => new
    {
        id = x.id,
        question = x.question,
        answers = x.answers
    }).ToList();
});

// Endpoint til at hente et enkelt spørgsmål baseret på ID
app.MapGet("/api/quiz/{id}", (int id) => {
    return questions.Select(x => new
    {
        id = x.id,
        question = x.question,
        answers = x.answers
    }).ToList().Find(x => x.id == id);
});

// Endpoint til validering af brugerens svar på et spørgsmål
app.MapPost("/api/quiz/{id}/validate", (int id, Input input) =>
{
    if (questions.Find(x => x.id == id).correct == input.input)
    {
        return true;
    }
    else
    {
        return false;
    }
});

app.Run();

// Model for et spørgsmål
record Question(int id, string question, string[] answers, int correct);
// Model for brugerens input
record Input(int input);



