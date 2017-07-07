using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LGG.Core.Dtos;
using LGG.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IPostTagService _postTagService;

        public PostsController(IPostService postService,
            ICategoryService categoryService,
            ITagService tagService,
            IPostTagService postTagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _postTagService = postTagService;
        }



        private Task<List<SelectListItem>> GetCategories()
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
            var tags = Task.Factory.StartNew(() => _tagService.GetAll().Select(s => new SelectListItem
            {
                Value = s.TagId.ToString(),
                Text = s.Name
            }).ToList());
            tags.Result.Insert(0, new SelectListItem { Value = "0", Text = "--chọn tag--" });
            return tags;
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
                ViewBag.Categories = await Task.Factory.StartNew(() => GetCategories()).Result;
                var tags = await Task.Factory.StartNew(() => _tagService.GetAll());
                ViewBag.Tags = JsonConvert.SerializeObject(tags);

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
                //ViewBag.Categories = await Task.Factory.StartNew(() => GetCategories()).Result;
                //var tags = await Task.Factory.StartNew(() => _tagService.GetAll());

                await Task.Factory.StartNew(() => _postService.Update(post));
                return RedirectToAction("Index");
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
                    var post = await Task.Factory.StartNew(() => _postService.GetById(id, true));
                    if (post != null)
                    {
                        ViewBag.Categories = await GetCategories();
                        var tags = await Task.Factory.StartNew(() => _tagService.GetAll());
                        var CurrentTags = string.Empty;
                        foreach (var tag in post.PostTags)
                        {
                            var match = tags.Where(x => x.TagId == tag.TagId).FirstOrDefault();
                            if (match != null)
                            {
                                CurrentTags += match.Name + ",";
                            }
                        }
                        ViewBag.CurrentTags = CurrentTags;
                        ViewBag.Tags = JsonConvert.SerializeObject(tags);
                        return View(post);
                    }
                }
                ModelState.AddModelError("", "Bài viết không còn tồn tại!");
                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(PostDto post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Task.Factory.StartNew(() => _postService.Update(post));
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
        public async Task<JsonResult> Delete(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    await Task.Factory.StartNew(() => _postService.Remove(url));
                    return Json("OK");
                }
                return Json("Error");
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
    }
}
