using Microsoft.EntityFrameworkCore;
using TLA.Persistence.Models;
using TLA.Persistence.Repository.Interfaces;

namespace TLA.Persistence.Repository.Implementations
{
    public class WordsRepository : IWordsRepository
    {
        private readonly IDbContextFactory<TranslationDb> _factory;

        public WordsRepository(IDbContextFactory<TranslationDb> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task AddSampleWord()
        {
            using (var ctx = await _factory.CreateDbContextAsync())
            {
                await ctx.Words.AddAsync(new Word { InputWord = "A", OutputWord = "B" });
                await ctx.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyCollection<Word>> GetAll()
        {
            var transactor = new Transactor<TranslationDb>(_factory);

            return await transactor.Query(async (ctx) =>
            {
                return await ctx.Words.ToListAsync();
            });


            //using (var ctx = await _factory.CreateDbContextAsync())
            //{
            //    var data = await ctx.Words.ToListAsync();
            //    return data;
            //}
        }
    }

    public class Transactor<TDbContext> where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _factory;

        public Transactor(IDbContextFactory<TDbContext> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<TResult> Query<TResult>(Func<TDbContext, Task<TResult>> func)
        {
            using (var ctx = await _factory.CreateDbContextAsync())
            {
                var data = await func(ctx);
                return data;
            }
        }
    }
}
