using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Controllers{
    public class PostController : Controller{
       private readonly IPostRepository _postRepo;
       
       public PostController(IPostRepository postRepo){
          _postRepo = postRepo;
       }

       [Route("/danh-sach/{alias}")]
       public async Task<IActionResult> GetAll(string alias){
            var postmodels = await Task.Factory.StartNew(() => _postRepo.getAllPostByCategoryByAlias(alias.Trim()));
            var posts = postmodels.Select(p => new PostViewModel{
                Name = p.Name,
                Alias = p.Alias,
                Image = p.Image,
                ShortDescription = p.ShortDescription
            }).ToList();
            ViewBag.Backlink = Commons.Backlink.GetBacklinkFromCate(alias);
            return View(posts);
       }

       [Route("/bai-viet/{alias}")]
       public async Task<IActionResult> Detail(string alias){
            try{
                var postmodel = await Task.Factory.StartNew(() => _postRepo.GetPostByAlias(alias.Trim()));
                var post = new PostViewModel(){
                    Name = postmodel.Name,
                    Alias = postmodel.Alias,
                    Image = postmodel.Image,
                    Content = postmodel.Content,
                    ShortDescription = postmodel.ShortDescription
                };
                ViewBag.Backlink = Commons.Backlink.GetBacklinkFromPost(alias);
                return View(post);
            }catch{return View("Error");}
       }
    }
}