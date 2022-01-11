using TLA.Infrastructure.GuidIdentifiers;
using TLA.Persistence.Models;
using TLA.Persistence.Repository.Interfaces;
using TLA.Persistence.Repository.Transactor;

namespace TLA.Persistence.Repository.Implementations
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ITransactor<TranslationDb> _transactor;
        private readonly IGuidProvider _guidProvider;

        public QuizRepository(ITransactor<TranslationDb> transactor, IGuidProvider guidProvider)
        {
            _transactor = transactor ?? throw new ArgumentNullException(nameof(transactor));
            _guidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
        }

        public async Task<Quiz> AddQuizAsync(string quizName) =>
            await _transactor.DoInTransaction(async ctx =>
            {
                var entity = new Quiz
                {
                    Name = quizName,
                    GuidIdentifier = _guidProvider.CreateNew()
                };

                await ctx.Quizes.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return entity;
            });
    }
}
