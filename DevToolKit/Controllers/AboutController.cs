using Microsoft.AspNetCore.Mvc;

namespace DevToolKit.Controllers
{
    public class AboutController : Controller
    {
        [HttpGet("/about")]
        public IActionResult Index()
        {
            return View();
        }
    }
} 