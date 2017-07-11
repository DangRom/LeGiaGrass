using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICompanyRepository _headRepo;
        public HeaderViewComponent(ICompanyRepository headRepo) => _headRepo = headRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var company = await Task.Factory.StartNew(() => _headRepo.GetCompanyForHead());
                var header = new HeaderViewModel()
                {
                    Slogan = company.Slogan,
                    BusinessHours = company.BusinessHours,
                    Hotline = company.Hotline,
                    Facebook = company.Facebook,
                    Google = company.Google,
                    Twitter = company.Twitter,
                };
                return View(header);
            }
            catch { throw; }
        }
    }
}