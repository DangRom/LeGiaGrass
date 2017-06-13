using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    [Route("admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin | Xin Chào!";
            return View();
        }
    }
}