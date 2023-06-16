using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            DbPath = "bin/TodoTask.db";
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