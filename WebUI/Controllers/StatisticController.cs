using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
