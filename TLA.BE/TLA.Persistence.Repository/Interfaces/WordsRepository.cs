using TLA.Persistence.Models;

namespace TLA.Persistence.Repository.Interfaces
{
    public interface IWordsRepository
    {
        Task<IReadOnlyCollection<Word>> GetAll();

        Task AddSampleWord();
    }
}
