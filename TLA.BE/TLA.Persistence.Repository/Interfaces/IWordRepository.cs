using TLA.Persistence.Models;

namespace TLA.Persistence.Repository.Interfaces
{
    public interface IWordRepository
    {
        Task<IReadOnlyCollection<Word>> GetAll();

        Task<IReadOnlyCollection<Word>> GetAllWithQuizGroup();

        Task AddSampleWord();

        Task<IReadOnlyCollection<Quiz>> GetAllQuizesWithWords();

        Task<Word> AddWordAsync(string inputWord, string outputWord, int quizId);
    }
}
