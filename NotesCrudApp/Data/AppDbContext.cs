using Microsoft.EntityFrameworkCore;
using NotesCrudApp.Model;

namespace NotesCrudApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Notes> Notes { get; set; } = null!;
    }
}
