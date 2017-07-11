using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "CategoryBlog")]
    public class CategoryBlogViewComponent : ViewComponent{
       private readonly ICategoryRepository _categoryRepo;
       public CategoryBlogViewComponent(ICategoryRepository categoryRepo) => _categoryRepo = categoryRepo;

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
               var categorymodels = await Task.Factory.StartNew(() => _categoryRepo.GetAllCategory());
               var categories = categorymodels.Select(p => new CategoryViewModel{
                 Name = p.Name,
                 Alias=p.Alias
               }).ToList();
               return View(categories);

          }catch{throw;}
       }
    }
}