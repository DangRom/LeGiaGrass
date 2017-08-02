using System.Threading.Tasks;
using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LeGiaGrass.Models;

namespace LeGiaGrass.ViewComponents{

    [ViewComponent(Name = "NewPost")]
    public class NewPostViewComponent : ViewComponent{
        private readonly IPostRepository _postRepo;

        public NewPostViewComponent(IPostRepository postRepo) => _postRepo = postRepo;

        public async Task<IViewComponentResult> InvokeAsync(string cate_alias){
            try{
                var cateId = Commons.SystemVariables.Categorys.FirstOrDefault(a => a.Alias == cate_alias).Id;
                var postOfCates = await Task.Factory.StartNew(() => _postRepo.GetNewPostByCategory(cateId));
                var posts = postOfCates.Select(p => new PostViewModel{
                    Name = p.Name,
                    Alias = p.Alias,
                    Image = p.Image,
                    ShortDescription = p.ShortDescription
                }).ToList();
                return View(posts);
            }catch{throw;}
        }
    }
}