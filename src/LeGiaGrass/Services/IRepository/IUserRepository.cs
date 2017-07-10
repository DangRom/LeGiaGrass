using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface IUserRepository : IRepositoriesBase<UserModel>{
       void Insert(UserModel model);
       void Update(UserModel model);
       UserModel GetUserByUserName(string username);
       IEnumerable<UserModel> GetAllUser();
       void Delete(string username);
       bool CheckUsername(string username);
       bool Login(string username, string password);
       void ChangePassword(string username, string password);
    }
}