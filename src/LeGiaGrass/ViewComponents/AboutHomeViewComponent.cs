using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace LeGiaGrass.ViewComponents
{

    [ViewComponent(Name = "AboutHome")]
    public class AboutHomeViewComponent : ViewComponent
    {
        private readonly ICompanyRepository _companyRepo;

        public AboutHomeViewComponent(ICompanyRepository companyRepo) => _companyRepo = companyRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var companyModel = await Task.Factory.StartNew(() => _companyRepo.GetCompanyForHome());
                var aboutHome =  new AboutHomeViewModel
                {
                    Description =companyModel.Description
                };
                
                return View(aboutHome);
            }
            catch { throw; }
        }
    }
}
