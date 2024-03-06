using Microsoft.EntityFrameworkCore;

// TODO:
// - Add Fluent API configuration to the ApplicationDbContext
namespace LinqNotesApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
