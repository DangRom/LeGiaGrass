#if (DEBUG)
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin | Categories";
            ViewBag.Selected = "categories";
            ViewBag.SystemJsImportPath = "app/components/categories/main.js";
            return View();
        }
    }
}
#endif