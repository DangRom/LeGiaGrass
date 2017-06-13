
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


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

        public IActionResult Index(int? count, int? page)
        {
            ViewBag.Title = "Admin | Galleries";
            ViewBag.Selected = "Galleries";
            ViewBag.Categories = _categoryService.GetAll();
            if (count == null || page == null)
                return View(_galleryService.GetAll());
            else
                return View(_galleryService.GetAllPaged((int)count, (int)page));
        }
    }
}