using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
namespace LeGiaGrass.Controllers
{
    public class ContactController : Controller
    {
        private readonly ICompanyRepository _companyRepo;
        public ContactController(ICompanyRepository companyRepo){
            _companyRepo = companyRepo;
        }

        /// <summary>
        /// GET: Contact
        /// </summary>
        [Route("/lien-he")]
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
            catch{return View("Error");}
        }

        // POST: /Contact/send
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Send(ContactViewModel model, string returnUrl)
        {
            try{
                if (!ModelState.IsValid)
                {
                    ViewBag.IsValid = false;
                    return View(model);
                }

                ViewBag.IsValid = true;

                return RedirectToAction(nameof(ContactController.Index));
            }catch{return View("Error");}
        }
    }
}