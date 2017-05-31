using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Pioneer.Pagination;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;
        private readonly IPaginatedMetaService _paginatedMetaService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IPostService _postService;

        public SearchController(ISearchService searchService,
            IPaginatedMetaService paginatedMetaService,
            ICategoryService categoryService,
            ITagService tagService,
            IPostService postService)
        {
            _searchService = searchService;
            _paginatedMetaService = paginatedMetaService;
            _categoryService = categoryService;
            _tagService = tagService;
            _postService = postService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Description = "LGG search page. ";

            ViewBag.Header = "Search";
            ViewBag.Title = "Search";
            ViewBag.Pager = "search";
            ViewBag.Selected = "search";

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.PopularPosts = _postService.GetPopularPosts();
            ViewBag.NewPosts = _postService.GetAll(true, false, false, 4).ToList();

            return View("../Search/Index", new List<PostDto>());
        }

        [HttpPost]
        public ActionResult Index(SearchRequest request)
        {
            var searchResults = _searchService.SearchPosts(request.Query, 5, request.Page);
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(searchResults.TotalMatchingPosts, request.Page, 5);

            ViewBag.Description = "LGG search results for \"" + request.Query + "\", page " + request.Page + ". " +
                                  "description...";

            ViewBag.Header = "Search";
            ViewBag.Title = "Search";
            ViewBag.Selected = "search";
            ViewBag.Query = request.Query;
            ViewBag.TotalQueryMatches = searchResults.TotalMatchingPosts;

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.PopularPosts = _postService.GetPopularPosts();
            ViewBag.NewPosts = _postService.GetAll(true, false, false, 4).ToList();

            return View("../Search/Index", searchResults.Posts);
        }

        [HttpGet("search/{query}/{page:int?}")]
        public ActionResult GetQuery(string query, int page = 1)
        {
            var searchResults = _searchService.SearchPosts(query, 5, page);
            ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(searchResults.TotalMatchingPosts, page, 5);

            ViewBag.Description = "LGG search results for \"" + query + "\", page " + page + ". " +
                                  "description";

            ViewBag.Header = "Search";
            ViewBag.Title = "Search";
            ViewBag.Selected = "search";
            ViewBag.Query = query;
            ViewBag.TotalQueryMatches = searchResults.TotalMatchingPosts;

            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.PopularPosts = _postService.GetPopularPosts();
            ViewBag.NewPosts = _postService.GetAll(true, false, false, 4).ToList();

            return View("../Search/Index", searchResults.Posts);
        }
    }
}
