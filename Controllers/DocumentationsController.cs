using Microsoft.AspNetCore.Mvc;

namespace Onyx.Controllers
{
    public class DocumentationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
