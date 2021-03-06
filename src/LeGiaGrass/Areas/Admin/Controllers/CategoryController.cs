using System;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Areas.Admin.Models;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Areas.Admin.Controllers{
   [Area("Admin")]
   [Authorize]
    public class CategoryController : Controller{
       private readonly ICategoryRepository _categoryRepo;
       public CategoryController(ICategoryRepository categoryRepo) => _categoryRepo = categoryRepo;

       public async Task<IActionResult> Index(){
          try{
            var categoriesModel = await Task.Factory.StartNew(() => _categoryRepo.GetAllCategory());
            var categories = categoriesModel.Select(c => new CategoryViewModel{
               Id = c.Id,
               Name = c.Name,
               Alias = c.Alias,
               Image = c.Image,
               Description = c.Description,
               Activated = c.Activated,
               Service = c.Service,
               Content = c.Content,
               Orders = c.Orders
            }).ToList();
            return View(categories);
          }catch(Exception ex){
             ModelState.AddModelError("",ex.Message);
             return View();
          }
       }

       public IActionResult New(){
          return View();
       }

       [HttpPost]
       public async Task<IActionResult> New(CategoryViewModel category){
          try{
            if(ModelState.IsValid){
               if(!await Task.Factory.StartNew(() => _categoryRepo.CheckAlias(category.Alias))){
                  var categoryModel = new CategoryModel(){
                     Name = category.Name,
                     Alias = category.Alias,
                     Image = category.Image,
                     Description = category.Description,
                     Activated = category.Activated,
                     Service = category.Service,
                     Orders = category.Orders,
                     Content = category.Content
                  };
                  await Task.Factory.StartNew(() => _categoryRepo.Insert(categoryModel));
                  return RedirectToAction("New");
               }
               ModelState.AddModelError("", "hãy thử tên khác hoặc kiểm tra lại định danh");
            }
            return View();
          }catch(Exception ex){
             ModelState.AddModelError("", ex.Message);
             return View();
          }
       }

       public async Task<IActionResult> Update(int id){
          try{
             var categoryModel = await Task.Factory.StartNew(() => _categoryRepo.GetCategoryById(id));
            if(categoryModel == null){
               ModelState.AddModelError("", "không tìm thấy dữ liệu");
               return View();
            }
            var category = new CategoryViewModel(){
               Id = categoryModel.Id,
               Name = categoryModel.Name,
               Alias = categoryModel.Alias,
               Image = categoryModel.Image,
               Description = categoryModel.Description,
               Activated = categoryModel.Activated,
               Service = categoryModel.Service,
               Orders = categoryModel.Orders,
               Content = categoryModel.Content
            };
            return View(category);
          }catch(Exception ex){
             ModelState.AddModelError("", ex.Message);
             return View();
          }
       }

       [HttpPost]
       public async Task<IActionResult> Update(CategoryViewModel category){
          try{
            if(ModelState.IsValid){
               var categoryModel = new CategoryModel(){
                  Id = category.Id,
                  Name = category.Name,
                  Alias = category.Alias,
                  Image = category.Image,
                  Description = category.Description,
                  Activated = category.Activated,
                  Service = category.Service,
                  Orders = category.Orders,
                  Content = category.Content
               };
               await Task.Factory.StartNew(() => _categoryRepo.Update(categoryModel));
               return RedirectToAction("Index");
            }
            return View();
          }catch(Exception ex){
             ModelState.AddModelError("", ex.Message);
             return View();
          }
       }

       [HttpDelete]
       public JsonResult Delete(int id){
          try{
            _categoryRepo.Delete(id);
            return Json("OK");
          }catch(Exception ex){
             return Json(ex.Message);
          }
       }
    }
}