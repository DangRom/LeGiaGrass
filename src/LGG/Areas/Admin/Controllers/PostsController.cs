using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        private Task<List<SelectListItem>> GetCategorys()
        {
            var categorys = Task.Factory.StartNew(() => _categoryService.GetAllForDropList().Select(s => new SelectListItem
            {
                Value = s.CategoryId.ToString(),
                Text = s.Name
            }).ToList());
            categorys.Result.Insert(0, new SelectListItem { Value = "0", Text = "--chọn danh mục--" });
            return categorys;
        }

        private Task<List<SelectListItem>> GetTags()
        {
            var categorys = Task.Factory.StartNew(() => _tagService.GetAll().Select(s => new SelectListItem
            {
                Value = s.TagId.ToString(),
                Text = s.Name
            }).ToList());
            categorys.Result.Insert(0, new SelectListItem { Value = "0", Text = "--chọn tag--" });
            return categorys;
        }


        public PostsController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var posts = await Task.Factory.StartNew(() => _postService.GetAllPostForAdmin());
                return View(posts);
            }
            catch { return View("Error"); }
        }

        public async Task<IActionResult> New()
        {
            try
            {
                ViewBag.Categories = await Task.Factory.StartNew(() => GetCategorys()).Result;
                ViewBag.Tags = await Task.Factory.StartNew(() => GetTags());
                PostDto post = new PostDto();
                _postService.Add(post);
                var model = _postService.GetByUrl(post.Url, false);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> New(PostDto post)
        {
            try
            {
                ViewBag.Categories = await Task.Factory.StartNew(() => GetCategorys()).Result;
                //ViewBag.Tags = await Task.Factory.StartNew(() => GetTags());
                //if (await Task.Factory.StartNew(() => _postService.CheckTitle(post.Title)))
                //{
                //    ModelState.AddModelError("", "hay thu tieu de khac");
                //    return View();
                //}
                await Task.Factory.StartNew(() => _postService.Update(post));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
