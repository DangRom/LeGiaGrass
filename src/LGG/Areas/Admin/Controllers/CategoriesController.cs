
using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var category = await Task.Factory.StartNew(() => _categoryService.GetAll());
                return View(category);
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New(CategoryDto category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await Task.Factory.StartNew(() => _categoryService.CheckName(category.Name)))
                    {
                        ModelState.AddModelError("", "Hãy thử tên chủ đề khác.");
                        return View();
                    }
                    await Task.Factory.StartNew(() => _categoryService.Add(category));
                    return RedirectToAction("New");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                if (id > 0)
                {
                    var category = await Task.Factory.StartNew(() => _categoryService.GetById(id));
                    return View(category);
                }
                ModelState.AddModelError("", "chủ đề này không tồn tại");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Task.Factory.StartNew(() => _categoryService.Update(category));
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await Task.Factory.StartNew(() => _categoryService.Remove(id));
                return Json("OK");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
