using LeGiaGrass.Services.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LeGiaGrass.Controllers{
    public class PostController : Controller{
       private readonly IPostRepository _postRepo;
       
       public PostController(IPostRepository postRepo){
          _postRepo = postRepo;
       }
    }
}