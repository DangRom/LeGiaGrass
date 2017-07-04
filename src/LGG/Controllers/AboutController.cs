using LGG.Core.Dtos;
using LGG.Core.Helpers;
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
        private readonly IPostService _postService;

        public AboutController(IOptions<CompanyDto> companyDefault, ICompanyService companyService, IPostService postService)
        {
            _companyService = companyService;
            _companyDefault = companyDefault;
            _postService = postService;
        }

        /// <summary>
        /// GET: About
        /// </summary>
        public IActionResult Index(string type)
        {
            switch (type)
            {
                case nameof(AboutType.About):
                    ViewBag.Selected = nameof(AboutType.About);
                    break;
                case nameof(AboutType.Privacy):
                    ViewBag.Selected = nameof(AboutType.Privacy);
                    break;
                case nameof(AboutType.TermsOfUse):
                    ViewBag.Selected = nameof(AboutType.TermsOfUse);
                    break;
                default:
                    break;
            }
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(CategoryName.Service));
            ViewBag.Company = _companyService.GetAll(true, false, false).FirstOrDefault() ?? _companyDefault.Value;
            return View();
        }
    }
}