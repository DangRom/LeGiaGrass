using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using LGG.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Text;

namespace LGG.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly ISiteMapService _siteMapService;
        private readonly ICommunicationService _communicationService;
        private readonly ICompanyService _companyService;
        private readonly IOptions<CompanyDto> _companyDefault;

        public HomeController(IPostService postService,
            ISiteMapService siteMapService,
            ICommunicationService communicationService,
            ICompanyService companyService,
            IOptions<CompanyDto> companyDefault)
        {
            _postService = postService;
            _siteMapService = siteMapService;
            _communicationService = communicationService;
            _companyService = companyService;
            _companyDefault = companyDefault;
        }

        public IActionResult Index()
        {
            ViewBag.Description =
                "Hi, my name is LGG...";

            //ViewBag.PopularPosts = _postService.GetPopularPosts().ToList();
            //ViewBag.LatestPosts = _postService.GetAll(true, false, false, 8).ToList();

            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault() ?? _companyDefault.Value;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //TODO: Figure out how to combine logic with Index
        public ActionResult SignUp(SignUpViewModel model)
        {
            ViewBag.Description =
                "Sign up for ...";

            ViewBag.PopularPosts = _postService.GetPopularPosts().ToList();
            ViewBag.LatestPosts = _postService.GetAll(true, false, false, 8).ToList();
            ViewBag.Anchor = "#home-sign-up";

            if (!ModelState.IsValid)
            {
                ViewBag.IsValid = false;
                return View("Index", model);
            }

            var response = _communicationService.SignUpToMailingList(model);

            if (response.Status != OperationStatus.Created)
            {
                ViewBag.IsValid = false;
                ViewBag.IsValidMessage = response.Message;
                return View("Index", model);
            }

            ViewBag.IsValid = true;

            return View("Index", model);
        }

        public IActionResult SiteMap()
        {
            return Content(_siteMapService.GetSiteMap(), "text/xml", Encoding.UTF8);
        }
    }
}