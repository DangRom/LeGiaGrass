﻿using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;

namespace LGG.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly ICompanyService _companyService;
        private readonly IOptions<CompanyDto> _companyDefault;

        public PostController(IPostService postService,
            ICategoryService categoryService,
            ITagService tagService,
            ICompanyService companyService,
            IOptions<CompanyDto> companyDefault)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _companyService = companyService;
            _companyDefault = companyDefault;
        }

        public IActionResult Index(string id)
        {
            var post = _postService.GetPreviousCurrentNextPost(id).ToList();
            ViewBag.Description = post[(int)PreviousCurrentNextPosition.Current].Description;

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.PopularPosts = _postService.GetPopularPosts();
            ViewBag.NewPosts = _postService.GetAll(true, false, false, 4).ToList();

            ViewBag.Company = _companyService.GetAll(false, false, false).FirstOrDefault() ?? _companyDefault.Value;
            return View(post);
        }
    }
}