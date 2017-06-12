
#if (DEBUG)
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Admin | Companies";
            ViewBag.Selected = "companies";

            var company = _companyService.GetCompanyFirstOrDefault(false, false, false);

            if (company == null)
                return View();
            else
                return View(company);
        }
    }
}
#endif