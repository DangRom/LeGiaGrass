using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IServices;
using LeGiaGrass.Services.IRepository;
namespace LeGiaGrass.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICommunicationService _communicationService;
        private readonly ICompanyRepository _companyRepo;
        public ContactController(ICommunicationService communicationService, ICompanyRepository companyRepo){
            _companyRepo = companyRepo;
            _communicationService = communicationService;
        }

        /// <summary>
        /// GET: Contact
        /// </summary>
        public async Task<IActionResult> Index()
        { 
             try{
                var companymodel = await Task.Factory.StartNew(() => _companyRepo.GetCompany());
                var company = new CompanyViewModel{

                };
                ViewBag.Company = company;
                ViewBag.IsValid = true;
                return View();
            }
            catch{throw;}
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
                return View(model);
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

            return RedirectToAction(nameof(ContactController.Index));
        }
    }
}