using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICompanyRepository _headRepo;
        public FooterViewComponent(ICompanyRepository headRepo) => _headRepo = headRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var company = await Task.Factory.StartNew(() => _headRepo.GetCompanyForFooter());
                var footer = new FooterViewModel()
                {
                    Name = company.Name,
                    Email = company.Email,
                    Phone = company.Phone,
                    Address=company.Address,
                    Slogan = company.Slogan,
                    BusinessHours = company.BusinessHours,
                    Hotline = company.Hotline,
                    Facebook = company.Facebook,
                    Google = company.Google,
                    Twitter = company.Twitter,
                };
                ViewBag.Service = Commons.SystemVariables.Services.Take(5);
                return View(footer);
            }
            catch { throw; }
        }
    }
}