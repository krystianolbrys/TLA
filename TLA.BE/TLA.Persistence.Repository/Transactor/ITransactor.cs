using Microsoft.EntityFrameworkCore;

namespace TLA.Persistence.Repository.Transactor
{
    public interface ITransactor<TDbContext> where TDbContext : DbContext
    {
        Task<TResult> Query<TResult>(Func<TDbContext, Task<TResult>> queryFunction);

        Task DoInTransaction(Func<TDbContext, Task> transactionFunction);

        Task<TResult> DoInTransaction<TResult>(Func<TDbContext, Task<TResult>> transactionFunction);
    }
}
