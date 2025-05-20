using Onyx.Models;

namespace Onyx.Repositories.Interfaces
{
    public interface IQuizRepository : IRepository<Quiz>
    {
        Task AddQuizAsync(Quiz quiz);
        Task<Quiz> GetQuizByIdAsync(int quizId);
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
        Task DeleteQuizAsync(int quizId);
    }
}
