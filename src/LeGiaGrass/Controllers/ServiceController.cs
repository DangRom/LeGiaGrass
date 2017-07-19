using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo = serviceRepo;
        }

        [Route("/dich-vu")]
        public async Task<IActionResult> GetAll(){
            var serviceModel = await Task.Factory.StartNew(() => _serviceRepo.GetAllServiceForList());
            var services = serviceModel.Select(s => new ServiceViewModel{
                Name = s.Name,
                Alias = s.Alias,
                Image = s.Image,
                ShortDescription = s.ShortDescription
            }).ToList();
            return View(services);
        }


        [Route("/dich-vu/{alias}")]
        public async Task<IActionResult> Detail(string alias)
        {
            var servicemodel = await Task.Factory.StartNew(() => _serviceRepo.GetServiceByAlias(alias.Trim()));
            var post = new ServiceViewModel
            {
                Name = servicemodel.Name ?? string.Empty,
                Alias = servicemodel.Alias ?? string.Empty,
                ShortDescription = servicemodel.ShortDescription ?? string.Empty,
                Content = servicemodel.Content ?? string.Empty,
                Image = servicemodel.Image ?? string.Empty
            };
            return View(post);
        }
    }
}