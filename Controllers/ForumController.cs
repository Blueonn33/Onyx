using Microsoft.AspNetCore.Mvc;

namespace Onyx.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
