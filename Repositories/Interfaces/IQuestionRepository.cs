using Onyx.Models;

namespace Onyx.Repositories.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task AddQuestionAsync(Question question);
        Task<Question> GetQuestionByIdAsync(int questionId);
        Task<IEnumerable<Question>> GetAllQuestionsByQuizIdAsync(int quizId);
        Task DeleteQuestionAsync(int questionId);
    }
}
