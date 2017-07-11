using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Models;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.ViewComponents{
   [ViewComponent(Name = "PostForHome")]
    public class PostForHomeViewComponent : ViewComponent{
       private readonly IPostRepository _postRepo;
       public PostForHomeViewComponent(IPostRepository postRepo) => _postRepo = postRepo;

       public async Task<IViewComponentResult> InvokeAsync(){
          try{
               var postmodel = await Task.Factory.StartNew(() => _postRepo.GetPostForHomePage());
               var posts = postmodel.Select(p => new PostViewModel{
                  Name = p.Name,
                  Alias = p.Alias,
                  ShortDescription = p.ShortDescription,
                  Image = p.Image,
                  CreateDate = p.CreateDate,
                  CreateDay = p.CreateDate.Day.ToString(),
                  CreateMonth = p.CreateDate.Month.ToString()
               }).Take(3).ToList();
               return View(posts);
          }catch{throw;}
       }
    }
}