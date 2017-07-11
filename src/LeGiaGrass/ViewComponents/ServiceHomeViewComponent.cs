using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "ServiceHome")]
    public class ServiceHomeViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepo;

        public ServiceHomeViewComponent(IServiceRepository serviceRepo) => _serviceRepo = serviceRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetAllServiceForHomePage());
                
                var services = servicemodels.Select(c => new ServiceHomeViewModel
                {
                    Name = c.Name,
                    Alias = c.Alias,
                    Image = c.Image,
                    ShortDescription = c.ShortDescription
                }).ToList();

                return View(services);
            }
            catch { throw; }
        }
    }
}