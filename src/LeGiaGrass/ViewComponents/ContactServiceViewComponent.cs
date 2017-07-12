using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using LeGiaGrass.Services.IServices;
namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "ContactService")]
    public class ContactServiceViewComponent : ViewComponent
    {
       private readonly ICommunicationService _communicationService;
        private readonly ICompanyRepository _companyRepo;

       public ContactServiceViewComponent(ICommunicationService communicationService, ICompanyRepository companyRepo){
            _companyRepo = companyRepo;
            _communicationService = communicationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
              try{
                var companymodel = await Task.Factory.StartNew(() => _companyRepo.GetCompany());
                var company = new CompanyViewModel{
                    Hotline = companymodel.Hotline,
                    BusinessHours =companymodel.BusinessHours,
                    Address = companymodel.Address
                };

                ViewBag.Company = company;
                ViewBag.IsValid = true;
                var contact = new ContactViewModel();
                return View(contact);
            }
            catch{throw;}
        }
    }
}