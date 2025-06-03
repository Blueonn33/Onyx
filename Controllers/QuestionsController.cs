using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Onyx.Models;
using Onyx.Repositories.Interfaces;
using Onyx.ViewModels;

namespace Onyx.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        public QuestionsController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index(int quizId)
        {
            ViewBag.quizId = quizId;
            if (quizId == 0)
            {
                return BadRequest("Невалидно ID на тест.");
            }

            var questions = await _questionRepository.GetAllQuestionsByQuizIdAsync(quizId);

            if(questions == null)
            {
                return NotFound();
            }

            return View(questions);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create(int quizId)
        {
            ViewBag.quizId = quizId;
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(int quizId, QuestionViewModel questionVm)
        {
            ViewBag.quizId = quizId;
            if (ModelState.IsValid)
            {
                if(quizId == 0)
                {
                    return BadRequest("Невалидно ID на тест.");
                }

                var question = new Question
                {
                    Title = questionVm.Title,
                    AnswerA = questionVm.AnswerA,
                    AnswerB = questionVm.AnswerB,
                    AnswerC = questionVm.AnswerC,
                    AnswerD = questionVm.AnswerD,
                    CorrectAnswer = questionVm.CorrectAnswer,
                    QuestionNumber = questionVm.QuestionNumber,
                    QuizId = quizId
                };
                await _questionRepository.AddQuestionAsync(question);
                return RedirectToAction(nameof(Index), new { quizId });
            }
            return View(questionVm);
        }
    }
}
