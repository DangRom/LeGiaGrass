using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent{
       private readonly IServiceRepository _serviceRepo;

       public MenuViewComponent(IServiceRepository serviceRepo){
          _serviceRepo = serviceRepo;
       }

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
               var servicemodels = await Task.Factory.StartNew(() => _serviceRepo.GetAllServiceForMenuLine());
                var menu = servicemodels.Select(c => new MenuViewModel
                {
                    Name = c.Name,
                    Alias = c.Alias
                }).ToList();

                return View(menu);
          } catch{throw;}
       }
    }
}