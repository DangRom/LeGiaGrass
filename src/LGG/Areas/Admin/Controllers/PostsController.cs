﻿#if (DEBUG)
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LGG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Admin | Posts";
            ViewBag.Selected = "posts";
            ViewBag.SystemJsImportPath = "app/components/posts/main.js";
            return View();
        }
    }
}
#endif