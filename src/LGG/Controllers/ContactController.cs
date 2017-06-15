using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using LGG.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace LGG.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContactController : Controller
    {
        private readonly ICommunicationService _communicationService;
        private readonly ICompanyService _companyService;
        private readonly IOptions<CompanyDto> _companyDefault;

        public ContactController(ICommunicationService communicationService,
            ICompanyService companyService,
            IOptions<CompanyDto> companyDefault)
        {
            _communicationService = communicationService;
            _companyService = companyService;
            _companyDefault = companyDefault;
        }

        /// <summary>
        /// GET: Contact
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Description = "Contact...";
            ViewBag.IsValid = true;
            ViewBag.Selected = "contact";
            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault() ?? _companyDefault.Value;

            return View();
        }


        // POST: /Contact/send
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IsValid = false;
                return View("~/Views/Contact/Index.cshtml");
            }

            var response = _communicationService.SendContactEmailNotification(model);
            ViewBag.IsValid = true;
            ViewBag.Selected = "contact";
            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault() ?? _companyDefault.Value;
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

            return View(nameof(ContactController.Index));
        }
    }
}