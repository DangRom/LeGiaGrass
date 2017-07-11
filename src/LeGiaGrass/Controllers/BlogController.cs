using System.Linq;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostRepository _postRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly ICompanyRepository _companyRepo;

        public BlogController(IPostRepository postRepo,
                ICategoryRepository categoryRepo,
                ICompanyRepository companyRepo)
        {
            _postRepo = postRepo;
            _categoryRepo = categoryRepo;
            _companyRepo = companyRepo;
        }

        // GET: Blog
        public ActionResult Index(int page = 1)
        {
            var postmodels = _postRepo.GetPostForHomePage();
            var posts = postmodels.Select(p => new PostViewModel
            {
                Name = p.Name,
                Alias = p.Alias,
                ShortDescriptions = p.ShortDescriptions,
                Image = p.Image,
                CreateDate = p.CreateDate
            }).ToList();
            return View(posts);
        }

        
        public ActionResult Post(string alias)
        {
            var postmodel = _postRepo.GetPostByAlias(alias.Trim());
            var post = new PostViewModel
            {
                Name = postmodel.Name,
                Alias = postmodel.Alias,
                ShortDescriptions = postmodel.ShortDescriptions,
                Content = postmodel.Content,
                Image = postmodel.Image,
                CreateDate = postmodel.CreateDate
            };
            return View(post);
        }

        // GET: Category
        public ActionResult Category(string id, int page = 1)
        {
            // var posts = _postService.GetAllByCategory(id, 10, page).ToList();
            // ViewBag.Categories = _categoryService.GetAll();
            // ViewBag.Tags = _tagService.GetAll();
            // ViewBag.NewPosts = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Blog), false, 5);
            // ViewBag.Services = _postService.GetAllByCategoryName(nameof(BaseCategoryName.Service));
            // ViewBag.Company = _companyService.GetAll().FirstOrDefault() ?? _companyDefault.Value;
            // ViewBag.Selected = "blog";
            //return View(nameof(BlogController.Index), posts);
            return View();
        }
    }
}