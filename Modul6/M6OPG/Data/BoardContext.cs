using Microsoft.EntityFrameworkCore;
using Model;

namespace Data
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<User> Users => Set<User>();

        public BoardContext()
        {
        }

        public BoardContext(DbContextOptions<BoardContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configure SQLite as the database provider
                optionsBuilder.UseSqlite("Data Source=bin/database.db");
            }
        }
    }
}
