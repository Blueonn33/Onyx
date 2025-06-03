using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Onyx.Models;
using Onyx.Repositories.Interfaces;
using Onyx.ViewModels;

namespace Onyx.Controllers
{
    public class QuizzesController : Controller
    {
        private readonly IQuizRepository _quizRepository;
        private readonly UserManager<IdentityUser> _userManager;
        public QuizzesController(IQuizRepository quizRepository, UserManager<IdentityUser> userManager)
        {
            _quizRepository = quizRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var quizzes = await _quizRepository.GetAllQuizzesAsync();
            return View(quizzes);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(QuizViewModel quizVm)
        {
            if (ModelState.IsValid)
            {
                byte[]? imageData = null;
                string? mimeType = null;

                if (quizVm.ImageFile != null && quizVm.ImageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await quizVm.ImageFile.CopyToAsync(ms);
                        imageData = ms.ToArray();
                        mimeType = quizVm.ImageFile.ContentType;
                    }
                }

                var quiz = new Quiz
                {
                    Title = quizVm.Title,
                    TimeLimit = quizVm.TimeLimit,
                    ImageData = imageData,
                    ImageMimeType = mimeType,
                    UserId = _userManager.GetUserId(User)
                };

                await _quizRepository.AddQuizAsync(quiz);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetImage(int quizId)
        {
            var quiz = await _quizRepository.GetQuizByIdAsync(quizId);

            if (quiz == null || quiz.ImageData == null || quiz.ImageMimeType == null)
            {
                return NotFound();
            }

            return File(quiz.ImageData, quiz.ImageMimeType);
        }
    }
}
