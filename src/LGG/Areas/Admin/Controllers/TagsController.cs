using System;
using System.Threading.Tasks;
using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TagsController : Controller
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int? count, int? page)
        {
            try{
                var tags = await Task.Factory.StartNew(() => _tagService.GetAll());
                return View(tags);
            }catch{return View("Error");}
        }

        public IActionResult New(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(TagDto tag){
            try{
                if(ModelState.IsValid){
                    if(await Task.Factory.StartNew(() => _tagService.CheckName(tag.Name))){
                        ModelState.AddModelError("", "Hay thu ten tag khac.");
                        return View();
                    }
                    await Task.Factory.StartNew(() => _tagService.Add(tag));
                    return RedirectToAction("New");
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
                    var tag = await Task.Factory.StartNew(() => _tagService.GetById(id));
                    if(tag != null){
                        return View(tag);
                    }
                }
                ModelState.AddModelError("", "du lieu khong ton tai");
                return View();
            }catch(Exception ex){
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(TagDto tag){
            try{
                if(ModelState.IsValid){
                    await Task.Factory.StartNew(() => _tagService.Update(tag));
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
                if(id>0){
                    await Task.Factory.StartNew(() => _tagService.Remove(id));
                    return Json("OK");
                }
                return Json("Error");
            }catch(Exception ex){
                return Json(ex.Message);
            }
        }
    }
}
