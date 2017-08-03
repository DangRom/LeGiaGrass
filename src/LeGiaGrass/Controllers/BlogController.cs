using System;
using System.Linq;
using System.Threading.Tasks;
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

        [Route("/tin-tuc")]
        public async Task<ActionResult> GetAll()
        {
            var postmodels = await Task.Factory.StartNew(() => _postRepo.GetPostForHomePage());
            var posts = postmodels.Select(p => new PostViewModel
            {
                Name = p.Name,
                Alias = p.Alias,
                ShortDescription = p.ShortDescription,
                Image = p.Image,
                CreateDate = p.CreateDate
            }).ToList();
            return View(posts);
        }

        [Route("/tin-tuc/{alias}")]
        public async Task<ActionResult> Detail(string alias)
        {
            try{
                var postmodel = await Task.Factory.StartNew(() => _postRepo.GetPostByAlias(alias.Trim()));
                var post = new PostViewModel
                {
                    Name = postmodel.Name,
                    Alias = postmodel.Alias,
                    ShortDescription = postmodel.ShortDescription,
                    Content = postmodel.Content,
                    Image = postmodel.Image,
                    CreateDate = postmodel.CreateDate
                };
                return View(post);
            }catch{
                return View("Error");
            }
        }

        // GET: Category
        public ActionResult Category(string alias)
        {
           var postmodels = _postRepo.getAllPostByCategoryByAlias(alias);
            var posts = postmodels.Select(p => new PostViewModel
            {
                Name = p.Name,
                Alias = p.Alias,
                ShortDescription = p.ShortDescription,
                Image = p.Image,
                CreateDate = p.CreateDate
            }).ToList();
            return View();
        }
    }
}