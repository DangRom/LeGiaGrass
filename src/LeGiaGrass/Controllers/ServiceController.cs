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
        [Route("/service/{alias}")]
        public IActionResult Index(string alias)
        {

            var servicemodel = _serviceRepo.GetServiceByAlias(alias.Trim());
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