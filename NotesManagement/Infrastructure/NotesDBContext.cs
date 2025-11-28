using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;
namespace Infrastructure
{
    public class NotesDBContext : DbContext
    {
        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options)
        {
        }
        public DbSet<Note> Note { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
