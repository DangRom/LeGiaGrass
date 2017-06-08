using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace LGG.Controllers
{
    public class AboutController : Controller
    {
        private readonly IOptions<CompanyDto> _companyDefault;
        private readonly ICompanyService _companyService;

        public AboutController(IOptions<CompanyDto> companyDefault, ICompanyService companyService)
        {
            _companyService = companyService;
            _companyDefault = companyDefault;
        }

        /// <summary>
        /// GET: About
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Description = "Description...";
            ViewBag.Selected = "about";
            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault() ?? _companyDefault.Value;
            return View();
        }
    }
}