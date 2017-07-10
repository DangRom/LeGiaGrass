using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent{
       private readonly ICategoryRepository _cateRepo;
       private readonly IPostRepository _postRepo;
       private readonly IServiceRepository _serviceRepo;

       public MenuViewComponent(ICategoryRepository cateRepo, IPostRepository postRepo,
         IServiceRepository serviceRepo){
          _cateRepo = cateRepo;
          _postRepo = postRepo;
          _serviceRepo = serviceRepo;
       }

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
               var menuheadmodel = await Task.Factory.StartNew(() => _cateRepo.GetCategoryForMenuHead());
               var menuhead = menuheadmodel.Select(h => new MenuHeadViewModel{
                  Id = h.Id,
                  Name = h.Name,
                  Alias = h.Alias,
                  Service = h.Service
               }).ToList();

               var menulinemodel = await Task.Factory.StartNew(() => _postRepo.GetMenuLine());
               var menuline = menulinemodel.Select(l => new MenuLineViewModel{
                  HeadId = l.CategoryId,
                  Name = l.Name,
                  Alias = l.Alias
               }).ToList();

               var category = menuheadmodel.FirstOrDefault(c => c.Service == true);
               if(category != null){
                  var serviceid = category.Id;
                  var servicemodels = _serviceRepo.GetAllServiceForMenuLine();
                  foreach(var c in servicemodels){
                      var service = new MenuLineViewModel(){
                        HeadId = serviceid,
                        Name = c.Name,
                        Alias = c.Alias
                      };
                      menuline.Add(service);  
                  }
               }

               var menu = new MenuViewModel();
               menu.MenuHead = menuhead;
               menu.MenuLine = menuline;
               return View(menu);
          }catch{throw;}
       }
    }
}