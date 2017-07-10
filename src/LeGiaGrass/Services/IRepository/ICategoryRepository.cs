using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface ICategoryRepository: IRepositoriesBase<CategoryModel>{
        void Insert(CategoryModel model);
        void Update(CategoryModel model);
        void Delete(int id);
        bool CheckAlias(string alias);
        CategoryModel GetCategoryById(int id);
        IEnumerable<CategoryModel> GetAllCategory();
        IEnumerable<CategoryModel> GetAllCategoryForPost();
        IEnumerable<CategoryModel> GetCategoryForMenuHead();
    }
}