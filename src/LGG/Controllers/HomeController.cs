using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using LGG.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
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
        private readonly IGalleryService _galleryService;

        public HomeController(IPostService postService,
            ISiteMapService siteMapService,
            ICommunicationService communicationService,
            ICompanyService companyService,
            IGalleryService galleryService,
            IOptions<CompanyDto> companyDefault)
        {
            _postService = postService;
            _siteMapService = siteMapService;
            _communicationService = communicationService;
            _companyService = companyService;
            _companyDefault = companyDefault;
            _galleryService = galleryService;
        }

        public IActionResult Index()
        {
            ViewBag.Selected = "home";
            ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;

            var galleries = _galleryService.GetByCategoryName(nameof(BaseCategoryName.Gallery));
            ViewBag.Galleries = (from gallery in galleries
                                 group gallery by gallery.Name
                                 into newGroup
                                 orderby newGroup.Key
                                 select newGroup).ToList();

            ViewBag.Posts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), false, 3).ToList();
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            ViewBag.Testimonials = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Testimonial));
            ViewBag.Events = _galleryService.GetByCategoryName(nameof(BaseCategoryName.Event));
            ViewBag.Slides = _galleryService.GetByCategoryName(nameof(BaseCategoryName.Slide));
            ViewBag.Diffirences = _galleryService.GetByCategoryName(nameof(BaseCategoryName.Diffirence));

            var ServiceSelectList = new List<SelectListItem>();
            foreach (var ser in (List<PostDto>)ViewBag.Services)
            {
                ServiceSelectList.Add(new SelectListItem { Value = ser.Title, Text = ser.Title });
            }

            ContactViewModel contact = new ContactViewModel()
            {
                ServiceSelectList = ServiceSelectList
            };
            return View(contact);
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


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsValid = false;
                return RedirectToAction(nameof(HomeController.Index));
            }

            var response = _communicationService.SendContactEmailNotification(model);
            ViewBag.IsValid = true;

            switch (response.Status)
            {
                case OperationStatus.Ok:
                    ViewBag.MessageSent = true;
                    break;
                case OperationStatus.Error:
                    ViewBag.IsValid = false;
                    ModelState.AddModelError("", "Xin lỗi vì sự bất tiện này, chúng tôi vừa gặp vấn đề khi gửi lời nhắn của bạn. Vui lòng thử lại!");
                    break;
            }

            return RedirectToAction(nameof(HomeController.Index));
        }
    }
}