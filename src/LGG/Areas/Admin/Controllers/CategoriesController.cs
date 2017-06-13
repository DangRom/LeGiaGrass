
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index(int? count, int? page)
        {
            ViewBag.Title = "Admin | Categories";
            ViewBag.Selected = "categories";

            if (count == null || page == null)
                return View(_categoryService.GetAll());
            else
                return View(_categoryService.GetAllPaged((int)count, (int)page));
        }
    }
}
