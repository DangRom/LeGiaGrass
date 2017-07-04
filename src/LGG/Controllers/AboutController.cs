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
        public IActionResult Index(string id)
        {
            switch (id)
            {
                case nameof(AboutType.About):
                    ViewBag.AboutType = AboutType.About;
                    break;
                case nameof(AboutType.Privacy):
                    ViewBag.AboutType = AboutType.Privacy;
                    break;
                case nameof(AboutType.TermsOfUse):
                    ViewBag.AboutType = AboutType.TermsOfUse;
                    break;
                default:
                    break;
            }

            ViewBag.Selected = "about";
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;
            return View();
        }
    }
}