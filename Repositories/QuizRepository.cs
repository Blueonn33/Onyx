using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Onyx.Data;
using Onyx.Models;
using Onyx.Repositories.Interfaces;

namespace Onyx.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        private readonly ApplicationDbContext _context;
        public QuizRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddQuizAsync(Quiz entity)
        {
            await _context.Quizzes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteQuizAsync(int quizId)
        {
            if(quizId == 0)
            {
                throw new ArgumentNullException(nameof(quizId));
            }

            var quiz = await _context.Quizzes.FindAsync(quizId);

            if (quiz == null)
            {
                throw new KeyNotFoundException($"Тест с ID {quizId} не е намерен.");
            }

            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            await _context.Quizzes.ToListAsync();
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ToListAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            if(quizId == 0)
            {
                throw new ArgumentNullException(nameof(quizId));
            }

            var quiz = await _context.Quizzes.FindAsync(quizId);

            if (quiz == null)
            {
                throw new KeyNotFoundException($"Тест с ID {quizId} не е намерен.");
            }

            return quiz;
        }
    }
}
