using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyRepository _companyRepo;
        public HomeController(ICompanyRepository companyRepo){
            _companyRepo = companyRepo;
        }
        public async Task<IActionResult> Index(){
            try{
                var companymodel = await Task.Factory.StartNew(() => _companyRepo.GetCompanyForHome());
                var company = new CompanyViewModel{
                    Description = companymodel.Description
                };
                return View(company);
            }catch{throw;}
        }

       
    }
}
