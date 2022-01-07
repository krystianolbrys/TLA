using Microsoft.EntityFrameworkCore;
using TLA.Persistence.Models;

namespace TLA.Persistence
{
    public class TranslationDb : DbContext
    {
        public TranslationDb(DbContextOptions<TranslationDb> options)
            : base(options) { }

        public DbSet<Word> Words { get; set; } = null!;
        public DbSet<Quiz> Quizes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Words)
                .WithOne(w => w.Quiz);
        }
    }
}
