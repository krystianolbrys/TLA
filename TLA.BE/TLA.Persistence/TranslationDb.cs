using Microsoft.EntityFrameworkCore;
using TLA.Persistence.Models;

namespace TLA.Persistence
{
    public class TranslationDb : DbContext
    {
        public TranslationDb(DbContextOptions<TranslationDb> options)
            : base(options) { }

        public DbSet<Word> Words { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasKey(c => c.Id);
        }
    }
}
