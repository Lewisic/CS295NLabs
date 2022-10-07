using Microsoft.AspNetCore.Mvc;

namespace IsaacLewisSite.Controllers
{
    public class SourcesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

        public IActionResult Links()
        {
            return View();
        }

    }
}
