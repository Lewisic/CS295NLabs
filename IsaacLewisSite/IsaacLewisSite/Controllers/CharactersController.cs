using Microsoft.AspNetCore.Mvc;

namespace IsaacLewisSite.Controllers
{
    public class CharactersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Anakin()
        {
            return View();
        }
        public IActionResult Luke()
        {
            return View();
        }

    }
}
