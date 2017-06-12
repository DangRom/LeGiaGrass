using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public PostsController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public IActionResult Index(int? countPerPage,
            int? currentPageIndex,
            bool includeExceprt = true,
            bool includeArticle = true,
            bool includeUnpublished = true)
        {
            ViewBag.Title = "Admin | Posts";
            ViewBag.Selected = "posts";
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();


            if (countPerPage == null || currentPageIndex == null)
                return View(_postService.GetAll(includeExceprt, includeArticle, includeUnpublished));
            else
                return View(_postService.GetAllPaged((int)countPerPage, (int)currentPageIndex, includeUnpublished));
        }
    }
}
