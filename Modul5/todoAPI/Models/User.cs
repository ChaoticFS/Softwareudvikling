using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public string? DbPath { get; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            DbPath = "bin/TodoTask.db";
        }

        public TaskContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}