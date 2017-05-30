using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;

namespace LGG.Core.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllPaged(int count, int page);
        Category GetById(int id);
        Category Add(Category map);
        void Update(CategoryDto category);
        void Remove(int id);
    }
}
