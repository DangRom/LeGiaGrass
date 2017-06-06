
#if (DEBUG)
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CompaniesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin | Companies";
            ViewBag.Selected = "companies";
            ViewBag.SystemJsImportPath = "app/components/companies/main.js";
            return View();
        }
    }
}
#endif