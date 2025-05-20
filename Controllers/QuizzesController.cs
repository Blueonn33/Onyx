using Microsoft.AspNetCore.Mvc;

namespace Onyx.Controllers
{
    public class QuizzesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(Quiz quiz)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Save the quiz to the database
        //        return RedirectToAction("Index");
        //    }
        //    return View(quiz);
        //}
    }
}
