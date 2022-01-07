using Microsoft.EntityFrameworkCore;

namespace TLA.Persistence.Repository.Transactor
{
    public class Transactor<TDbContext> : ITransactor<TDbContext>
        where TDbContext : DbContext
    {
        private readonly IDbContextFactory<TDbContext> _factory;

        public Transactor(IDbContextFactory<TDbContext> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public async Task<TResult> DoInTransaction<TResult>(Func<TDbContext, Task<TResult>> transactionFunction)
        {
            using (var ctx = await _factory.CreateDbContextAsync())
            {
                try
                {
                    await ctx.Database.BeginTransactionAsync();
                    var data = await transactionFunction(ctx);
                    await ctx.Database.CommitTransactionAsync();
                    return data;
                }
                catch (Exception ex)
                {
                    await ctx.Database.RollbackTransactionAsync();
                    throw new DbUpdateException($"Transaction Rollbacked {ex}");
                }
            }
        }

        public async Task DoInTransaction(Func<TDbContext, Task> transactionFunction)
        {
            using (var ctx = await _factory.CreateDbContextAsync())
            {
                try
                {
                    await ctx.Database.BeginTransactionAsync();
                    await transactionFunction(ctx);
                    await ctx.Database.CommitTransactionAsync();
                }
                catch (Exception ex)
                {
                    await ctx.Database.RollbackTransactionAsync();
                    throw new DbUpdateException($"Transaction Rollbacked {ex}");
                }
            }
        }

        public async Task<TResult> Query<TResult>(Func<TDbContext, Task<TResult>> queryFunction)
        {
            using (var ctx = await _factory.CreateDbContextAsync())
            {
                var data = await queryFunction(ctx);
                return data;
            }
        }
    }
}
