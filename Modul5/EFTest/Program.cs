using Models;

using (var db = new TaskContext())
{
    Console.WriteLine($"Database path: {db.DbPath}.");

    // Create
    Console.WriteLine("Indsæt et nyt task");
    User user = new User(1, "Asger", "asn@mail.dk");
    db.Add(user);
    db.Add(new TodoTask("Design ERD", "planning", user, false));

    //db.Remove(db.Tasks.Find((long)2));

    db.SaveChanges();

    // Read
    Console.WriteLine("Find det sidste task");
    var lastTask = db.Tasks
        .OrderBy(b => b.TodoTaskId)
        .Last();
    Console.WriteLine($"Text: {lastTask.Text}");
}