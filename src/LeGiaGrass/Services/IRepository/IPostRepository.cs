using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface IPostRepository : IRepositoriesBase<PostModel>{
       bool CheckAlias(string alias);
       void Insert(PostModel model);
       void Update(PostModel model);
       void Delete(int id);
       PostModel GetPostById(int id);
       IEnumerable<PostModel> GetAllPost();
       IEnumerable<PostModel> GetPostForHomePage();
       IEnumerable<PostModel> GetMenuLine();
       IEnumerable<PostModel> GetForFooter();
    }
}