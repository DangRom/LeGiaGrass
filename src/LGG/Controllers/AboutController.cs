using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LGG.Controllers
{
    public class AboutController : Controller
    {
        private readonly ICompanyService _companyService;

        public AboutController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// GET: About
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Description = "Description...";
            ViewBag.Selected = "about";
            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault();
            return View();
        }
    }
}