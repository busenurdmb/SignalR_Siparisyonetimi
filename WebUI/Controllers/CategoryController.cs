using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
