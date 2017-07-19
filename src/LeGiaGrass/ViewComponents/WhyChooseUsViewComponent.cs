using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
    [ViewComponent(Name = "WhyChooseUs")]
    public class WhyChooseUsViewComponent : ViewComponent{
        private readonly ICompanyRepository _companyRepo;

        public WhyChooseUsViewComponent(ICompanyRepository companyRepo) => _companyRepo = companyRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var companyModel = await Task.Factory.StartNew(() => _companyRepo.GetCompanyForHome());
                var aboutHome =  new AboutHomeViewModel
                {
                    WhyChooseUs =companyModel.WhyChooseUs
                };
                
                return View(aboutHome);
            }
            catch { throw; }
        }
    }
}