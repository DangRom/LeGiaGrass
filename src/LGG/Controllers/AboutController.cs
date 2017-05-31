using Microsoft.AspNetCore.Mvc;

namespace LGG.Controllers
{
    public class AboutController : Controller
    {
        /// <summary>
        /// GET: About
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Description = "Description...";
            ViewBag.Selected = "about";
            return View();
        }
    }
}