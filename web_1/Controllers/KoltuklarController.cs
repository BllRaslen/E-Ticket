using Microsoft.AspNetCore.Mvc;

namespace web_1.Controllers
{
    public class KoltuklarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
