
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using LGG.Core.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleriesController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly ICategoryService _categoryService;
        private Task<List<SelectListItem>> GetCategorys(){
            var categorys = Task.Factory.StartNew(() => _categoryService.GetAllForDropList().Select(s => new SelectListItem{
                Value = s.CategoryId.ToString(),
                Text = s.Name
            }).ToList());
            categorys.Result.Insert(0, new SelectListItem{Value = "0", Text = "--chọn danh mục--"});
            return categorys;
        }
        public GalleriesController(IGalleryService galleryService, ICategoryService categoryService)
        {
            _galleryService = galleryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? count, int? page)
        {
            try{
                var gall = await Task.Factory.StartNew(() => _galleryService.GetAll());
                return View(gall);
            }catch{
                return View("Error");
            }
        }

        public async Task<IActionResult> New(){
            try{
                ViewBag.Categorys = await GetCategorys();
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> New(GalleryDto gallery){
            try{
                ViewBag.Categorys = await GetCategorys();
                if(ModelState.IsValid){
                    if(await Task.Factory.StartNew(() => _galleryService.CheckName(gallery.Name))){
                        ModelState.AddModelError("", "Hay thu ten khac.");
                        return View();
                    }else{
                        await Task.Factory.StartNew(() => _galleryService.Add(gallery));
                        return RedirectToAction("New");
                    }
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Update(int id){
            try{
                if(id > 0){
                    var gallery = await Task.Factory.StartNew(() => _galleryService.GetById(id));
                    if(gallery != null){
                        ViewBag.Categorys = await GetCategorys();
                        return View(gallery);
                    }
                }
                ModelState.AddModelError("", "du lieu khong ton tai.");
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(GalleryDto gallery){
            try{
                if(ModelState.IsValid){
                    await Task.Factory.StartNew(() => _galleryService.Update(gallery));
                    return RedirectToAction("Index");
                }
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id){
            try{
                if(id > 0){
                    await Task.Factory.StartNew(() => _galleryService.Remove(id));
                    return Json("OK");
                }
                return Json("Error");
            }catch{
                return Json("Error");
            }
        }
    }
}