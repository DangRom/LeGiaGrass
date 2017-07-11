using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IServices;
using LeGiaGrass.Services.IRepository;

namespace LeGiaGrass.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepo;
        public ServiceController(IServiceRepository serviceRepo)
        {
            _serviceRepo=serviceRepo;
        }
        public IActionResult Index(string alias)
        {

            var servicemodel = _serviceRepo.GetServiceByAlias(alias.Trim());
            var post = new ServiceViewModel
            {
                Name = servicemodel.Name,
                Alias = servicemodel.Alias,
                ShortDescription = servicemodel.ShortDescription,
                Content = servicemodel.Content,
                Image = servicemodel.Image
            };
            return View(post);
        }
    }
}