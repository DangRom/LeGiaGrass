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

        public IActionResult Index(int? count, int? page)
        {
            ViewBag.Title = "Admin | Tags";
            ViewBag.Selected = "tags";
            if (count == null || page == null)
                return View(_tagService.GetAll());
            else
                return View(_tagService.GetAllPaged((int)count, (int)page));
        }
    }
}
