using Microsoft.EntityFrameworkCore;
using Onyx.Data;
using Onyx.Models;
using Onyx.Repositories.Interfaces;

namespace Onyx.Repositories
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task AddQuestionAsync(Question entity)
        {
            await _context.Questions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuestionAsync(int questionId)
        {
            if(questionId == 0)
            {
                throw new ArgumentNullException(nameof(questionId));
            }

            var question = await _context.Questions.FindAsync(questionId);

            if(question == null)
            {
                throw new KeyNotFoundException($"Въпрос с ID {questionId} не е намерен.");
            }

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Question>> GetAllQuestionsByQuizIdAsync(int quizId)
        {
            if(quizId == 0)
            {
                throw new ArgumentNullException(nameof(quizId));
            }

            var questions = await _context.Questions.Where(q => q.QuizId == quizId).ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                throw new KeyNotFoundException($"Въпроси с ID {quizId} на тест не са намерени.");
            }

            return questions;
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            if(questionId == 0)
            {
                throw new ArgumentNullException(nameof(questionId));
            }

            var question = await _context.Questions.FindAsync(questionId);

            if (question == null)
            {
                throw new KeyNotFoundException($"Въпрос с ID {questionId} не е намерен.");
            }

            return question;
        }
    }
}
