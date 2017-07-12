using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents
{
    [ViewComponent(Name = "NewService")]
    public class NewServiceViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepo;
        public NewServiceViewComponent(IServiceRepository serviceRepo) => _serviceRepo = serviceRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetAllServiceForServicePage());

                var services = servicemodels.Select(s => new ServiceViewModel
                {
                    Name = s.Name ?? string.Empty,
                    Alias = s.Alias ?? string.Empty,
                    ShortDescription = s.ShortDescription ?? string.Empty,
                    Content = s.Content ?? string.Empty,
                    Image = s.Image ?? string.Empty
                }).ToList();
                return View(services);
            }
            catch { throw; }
        }
    }
}