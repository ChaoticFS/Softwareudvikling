using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    // DbContext-klasse, der håndterer forbindelsen til databasen og mapper modeller til tabeller
    public class TaskContext : DbContext
    {
        // DbSet, der repræsenterer "Tasks"-tabellen i databasen
        public DbSet<TodoTask> Tasks { get; set; }

        // DbSet, der repræsenterer "Users"-tabellen i databasen
        public DbSet<User> Users { get; set; }

        // Sti til databasen (valgfrit)
        public string? DbPath { get; }

        // Konstruktør, der modtager DbContextOptions som argument (bruges normalt ved runtime)
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            DbPath = "bin/TodoTask.db"; // Sti til databasen
        }

        // Standardkonstruktør (kan bruges til test eller uden DbContextOptions)
        public TaskContext()
        {
        }

        // Konfigurerer databasen og forbindelsesindstillingerne
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}"); // Bruger SQLite-databasen og angiver stien til databasen

        // Definerer modelkonfigurationen og tabellernes navne
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks"); // Konfigurerer "Tasks"-modellen til at blive gemt i "Tasks"-tabellen
            modelBuilder.Entity<User>().ToTable("Users"); // Konfigurerer "User"-modellen til at blive gemt i "Users"-tabellen
        }
    }
}
