using TLA.Persistence.Models;

namespace TLA.Persistence.Repository.Interfaces
{
    public interface IQuizRepository
    {
        Task<Quiz> AddQuizAsync(string quizName);
    }
}
