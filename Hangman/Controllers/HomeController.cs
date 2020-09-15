using Microsoft.AspNetCore.Mvc;

namespace Hangman.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}