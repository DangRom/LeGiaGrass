
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class GalleriesController : Controller
    {
        private readonly IGalleryService _galleryService;
        private readonly ICategoryService _categoryService;
        public GalleriesController(IGalleryService galleryService, ICategoryService categoryService)
        {
            _galleryService = galleryService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? count, int? page)
        {
            try{
                var gall = await Task.Factory.StartNew(() => _galleryService.GetAll());
                ViewBag.Categorys = await Task.Factory.StartNew(() => _categoryService.GetAllForDropList());
                return View(gall);
            }catch{
                return View("Error");
            }
        }
    }
}