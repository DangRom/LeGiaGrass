using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Commons;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent{
       private readonly IServiceRepository _serviceRepo;
       private readonly ICategoryRepository _cateRepo;
       private readonly IPostRepository _postRepo;

       public MenuViewComponent(IServiceRepository serviceRepo, ICategoryRepository cateRepo,
        IPostRepository postRepo){
          _serviceRepo = serviceRepo;
          _cateRepo = cateRepo;
          _postRepo = postRepo;
       }

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
              var menu = new MenuViewModel();

               var menuheadModel = await Task.Factory.StartNew(() => _cateRepo.GetCategoryForMenuHead());
               var menuhead = menuheadModel.Select(h => new MenuHeadViewModel{
                   Id = h.Id,
                   Name = h.Name,
                   Alias = h.Alias,
                   Service = h.Service,
                   News = h.News
               }).ToList();
               SystemVariables.Categorys = menuhead;

               var menulineModel = await Task.Factory.StartNew(() => _postRepo.GetMenuLine());
               var menuline = menulineModel.Select(l => new MenuLineViewModel{
                   Name = l.Name,
                   Alias = l.Alias,
                   HeadId = l.CategoryId
               }).ToList();
               SystemVariables.Services = menuline;

               var serviceId = menuheadModel.FirstOrDefault(s => s.Service == true);
               if(serviceId != null){
                   var serviceModels = _serviceRepo.GetAllServiceForMenuLine();
                   foreach(var s in serviceModels){
                        var service = new MenuLineViewModel(){
                            Name = s.Name,
                            Alias = s.Alias,
                            HeadId = serviceId.Id
                        };
                        menuline.Add(service);
                        SystemVariables.Services.Append(service);
                   }
               }

                menu.MenuHeads = menuhead;
                menu.MenuLines = menuline;

               return View(menu);
          } catch{throw;}
       }
    }
}