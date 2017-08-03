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
    public class AboutController : Controller
    {
      private readonly ICompanyRepository _companyRepo;
        public AboutController(ICompanyRepository companyRepo){
            _companyRepo = companyRepo;
        }

        [Route("/ve-chung-toi")]
        public async Task<IActionResult> Index(){
            try{
                var companymodel = await Task.Factory.StartNew(() => _companyRepo.GetCompanyForAbout());
                var company = new AboutPageViewModel{
                    About = companymodel.About
                };
                return View(company);
            }catch{return View("Error");}
        }
    }
}