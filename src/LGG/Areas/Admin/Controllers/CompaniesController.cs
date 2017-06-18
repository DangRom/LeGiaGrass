using System.Threading.Tasks;
using LGG.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using LGG.Core.Services;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        public CompaniesController(ICompanyService companyservce) => _companyService = companyservce;

        public async Task<IActionResult> Index()
        {
            try{
                var company = await Task.Factory.StartNew(() => _companyService.GetCompany());
                return View(company);
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Index(CompanyDto company){
            try{
                if(ModelState.IsValid){
                    var companymodel = await Task.Factory.StartNew(() => _companyService.GetCompany());
                    if(companymodel == null){
                        await Task.Factory.StartNew(() => _companyService.Add(company));
                    }else{
                        company.Id = companymodel.Id;
                        await Task.Factory.StartNew(() => _companyService.Update(company));
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}