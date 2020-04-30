using Microsoft.AspNetCore.Mvc;

namespace WebIVBackend.Controllers
{
    public class DayController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}