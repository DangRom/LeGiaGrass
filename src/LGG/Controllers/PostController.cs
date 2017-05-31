using LGG.Core.Helpers;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LGG.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(string id)
        {
            var post = _postService.GetPreviousCurrentNextPost(id).ToList();
            ViewBag.Description = post[(int)PreviousCurrentNextPosition.Current].Description;
            ViewBag.PopularPosts = _postService.GetPopularPosts();
            return View(post);
        }
    }
}