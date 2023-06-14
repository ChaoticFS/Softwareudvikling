using Notit.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Thread = Notit.Shared.Models.Thread;

namespace Notit.API.Models
{
    public class NotitContext : DbContext
    {
        public DbSet<Thread> Threads => Set<Thread>();
        public DbSet<Comment> Comments => Set<Comment>();
        
        public NotitContext(DbContextOptions<NotitContext> options) 
            : base(options) { }
    }
}
