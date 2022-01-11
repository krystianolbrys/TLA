using Microsoft.EntityFrameworkCore;
using TLA.Infrastructure.GuidIdentifiers;
using TLA.Persistence.Models;
using TLA.Persistence.Repository.Interfaces;
using TLA.Persistence.Repository.Transactor;

namespace TLA.Persistence.Repository.Implementations
{
    public class WordRepository : IWordRepository
    {
        private readonly ITransactor<TranslationDb> _transactor;
        private readonly IGuidProvider _guidProvider;

        public WordRepository(ITransactor<TranslationDb> transactor, IGuidProvider guidProvider)
        {
            _transactor = transactor ?? throw new ArgumentNullException(nameof(transactor));
            _guidProvider = guidProvider ?? throw new ArgumentNullException(nameof(guidProvider));
        }

        public async Task AddSampleWord()
        {
            await _transactor.DoInTransaction(async ctx =>
            {
                await ctx.Quizes.AddAsync(new Quiz { Name = "Basic", GuidIdentifier = Guid.NewGuid() });
                await ctx.SaveChangesAsync();

                var quiz = await ctx.Quizes.OrderByDescending(c => c.Id).FirstAsync();

                quiz!.Words.Add(new Word { InputWord = "InputSample", OutputWord = "OutSample", GuidIdentifier = Guid.NewGuid() });
                quiz!.Words.Add(new Word { InputWord = "InputSample", OutputWord = "OutSample", GuidIdentifier = Guid.NewGuid() });
                quiz!.Words.Add(new Word { InputWord = "InputSample", OutputWord = "OutSample", GuidIdentifier = Guid.NewGuid() });

                await ctx.SaveChangesAsync();
            });
        }

        public async Task<Word> AddWordAsync(string inputWord, string outputWord, int quizId) =>
            await _transactor.DoInTransaction(async ctx =>
            {
                var entity = new Word
                {
                    InputWord = inputWord,
                    OutputWord = outputWord,
                    QuizId = quizId,
                    GuidIdentifier = _guidProvider.CreateNew()
                };

                await ctx.Words.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return entity;
            });

        public async Task<IReadOnlyCollection<Word>> GetAll()
        {
            return await _transactor.Query(async (ctx) =>
            {
                return await ctx.Words.ToListAsync();
            });
        }

        public async Task<IReadOnlyCollection<Quiz>> GetAllQuizesWithWords() =>
            await _transactor.Query(async (ctx) =>
            {
                return await ctx.Quizes
                    .Include(w => w.Words)
                    .ToListAsync();
            });

        public async Task<IReadOnlyCollection<Word>> GetAllWithQuizGroup()
        {
            return await _transactor.Query(async (ctx) =>
            {
                return await ctx.Words
                    .Include(w => w.Quiz)
                    .ToListAsync();
            });
        }
    }
}
