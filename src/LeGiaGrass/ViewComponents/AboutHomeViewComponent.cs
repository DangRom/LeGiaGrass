using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Areas.Admin.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace LeGiaGrass.ViewComponents
{

    [ViewComponent(Name = "AboutHome")]
    public class AboutHomeViewComponent : ViewComponent
    {
        private readonly IServiceRepository _serviceRepo;

        public AboutHomeViewComponent(IServiceRepository serviceRepo) => _serviceRepo = serviceRepo;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetAllServiceForHomePage());
                var services = servicemodels.Select(c => new ServiceViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Alias = c.Alias,
                    Price = c.Price,
                    Image = c.Image,
                    ShortDescription = c.ShortDesciptions
                }).ToList();
                return View(services);
            }
            catch { throw; }
        }
    }
}
