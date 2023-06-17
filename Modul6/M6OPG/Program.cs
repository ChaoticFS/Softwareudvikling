using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using Data;
using Model;

BoardContext db = new BoardContext();
db.Users.Add(new User { Name = "Axel" });
db.SaveChanges();
