using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "NewPostBlog")]
    public class NewPostBlogViewComponent : ViewComponent{
       private readonly IPostRepository _postRepo;
       public NewPostBlogViewComponent(IPostRepository postRepo) => _postRepo = postRepo;

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
               var postmodel = await Task.Factory.StartNew(() => _postRepo.GetPostForHomePage());
               var posts = postmodel.Select(p => new PostViewModel{
                  Name = p.Name,
                  Alias = p.Alias,
                  Image = p.Image,
                  CreateDate = p.CreateDate
               }).Take(3).ToList();
               return View(posts);
          }catch{throw;}
       }
    }
}