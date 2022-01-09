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
        public DbSet<UserResult> UserResults { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Words)
                .WithOne(w => w.Quiz);

            modelBuilder.Entity<UserResult>()
                .HasOne(ur => ur.User);

            modelBuilder.Entity<UserResult>()
                .HasOne(ur => ur.Word);

            SetGuidIdentifiersAsUniqueIndex(modelBuilder);
        }

        private void SetGuidIdentifiersAsUniqueIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.GuidIdentifier)
                .IsUnique();

            modelBuilder.Entity<Quiz>()
                .HasIndex(u => u.GuidIdentifier)
                .IsUnique();

            modelBuilder.Entity<Word>()
                .HasIndex(u => u.GuidIdentifier)
                .IsUnique();
        }
    }
}
