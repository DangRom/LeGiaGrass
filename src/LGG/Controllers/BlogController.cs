using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pioneer.Pagination;
using System.Linq;

namespace LGG.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IPaginatedMetaService _paginatedMetaService;
        private readonly ICompanyService _companyService;
        private readonly IOptions<CompanyDto> _companyDefault;

        public BlogController(IPostService postService,
                ICategoryService categoryService,
                ITagService tagService,
                IPaginatedMetaService paginatedMetaService,
                ICompanyService companyService,
                IOptions<CompanyDto> companyDefault)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
            _paginatedMetaService = paginatedMetaService;
            _companyService = companyService;
            _companyDefault = companyDefault;
        }

        // GET: Blog
        public ActionResult Index(int page = 1)
        {
            ///TODO: Chưa làm paging, đang xử lý khi null
            //ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(_postService.GetTotalNumberOfPosts(), page, 1);
            //ViewBag.Header = "LGG";
            //ViewBag.Title = "LGG";
            //ViewBag.Pager = "blog";
            //ViewBag.PopularPosts = _postService.GetPopularPosts();

            var posts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), true);
            ViewBag.Selected = "blog";
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.NewPosts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), false, 5);
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;
            return View(posts);
        }

        // GET: Tag
        public ActionResult Tag(string id, int page = 1)
        {
            ///TODO: Chưa làm paging, đang xử lý khi null
            // ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(_postService.GetTotalNumberOfPostByTag(id), page, 4);
            //ViewBag.Title = _tagService.GetTagNameFromTagUrlInTagCollection(id, posts[0].Tags.ToList());
            //ViewBag.Description = "LGG " + page + ", for tag \"" + tag + "\". " +
            //                      "LGG";
            //ViewBag.Header = "Tag : " + tag;
            //ViewBag.Pager = "tag/" + id;
            //ViewBag.PopularPosts = _postService.GetPopularPosts();


            var posts = _postService.GetAllByTag(id, 10, page).ToList();
            // var tag = posts[0].Tags.Where(x => x.Url == id).ToList()[0].Name;
            ViewBag.Selected = "blog";
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.NewPosts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), false, 5);
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;
            return View(nameof(BlogController.Index), posts);
        }

        // GET: Category
        public ActionResult Category(string id, int page = 1)
        {

            ///TODO: Chưa làm paging, đang xử lý khi null
            //ViewBag.PaginatedMeta = _paginatedMetaService.GetMetaData(_postService.GetTotalNumberOfPostsByCategory(id), page, 4);

            //ViewBag.Description = "LGG " + page + ", for category \"" + posts[0].Category.Name + "\". " +
            //                      "description...";
            //ViewBag.Header = "Category : " + posts[0].Category.Name;
            //ViewBag.Title = posts[0].Category.Name;
            //ViewBag.Pager = "category/" + id;
            //ViewBag.PopularPosts = _postService.GetPopularPosts();

            var posts = _postService.GetAllByCategory(id, 10, page).ToList();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.Tags = _tagService.GetAll();
            ViewBag.NewPosts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), false, 5);
            ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;
            ViewBag.Selected = "blog";
            return View(nameof(BlogController.Index), posts);
        }
    }
}