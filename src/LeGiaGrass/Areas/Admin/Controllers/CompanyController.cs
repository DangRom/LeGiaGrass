using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Services.Models;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace LeGiaGrass.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]    
    public class CompanyController:Controller
    {
        private readonly ICompanyRepository _companyRepo;

        public CompanyController(ICompanyRepository companyRepo) => _companyRepo = companyRepo;

        public IActionResult Index(){
            try{
                var companyModel = _companyRepo.GetCompany();
                if(companyModel == null) return View(new CompanyViewModel());
                var company = new CompanyViewModel(){
                    Name = companyModel.Name,
                    Address = companyModel.Address,
                    Email = companyModel.Email,
                    Hotline = companyModel.Hotline,
                    Phone = companyModel.Phone,
                    TaxCode = companyModel.TaxCode,
                    Google = companyModel.Google,
                    Twitter = companyModel.Twitter,
                    Facebook = companyModel.Facebook,
                    Description = companyModel.Description,
                    About = companyModel.About,
                    Slogan = companyModel.Slogan,
                    BusinessHours = companyModel.BusinessHours,
                    Logo = companyModel.Logo
                };
                return View(company);
            }catch(Exception ex){
                ModelState.AddModelError("",ex.Message);
                return View();
            }
        }

        [HttpPost]
        public IActionResult Index(CompanyViewModel company){
            try{
                if(ModelState.IsValid){
                    var companyModel = new CompanyModel(){
                        Name = company.Name,
                        Address = company.Address,
                        Email = company.Email,
                        Hotline = company.Hotline,
                        Phone = company.Phone,
                        TaxCode = company.TaxCode,
                        Google = company.Google,
                        Twitter = company.Twitter,
                        Facebook = company.Facebook,
                        Description = company.Description,
                        About = company.About,
                        Slogan = company.Slogan,
                        BusinessHours = company.BusinessHours,
                        Logo = company.Logo
                    };
                    _companyRepo.SaveCompany(companyModel);
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
