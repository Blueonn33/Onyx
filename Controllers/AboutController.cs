using Microsoft.AspNetCore.Mvc;

namespace Onyx.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
