using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAll();
        IEnumerable<CategoryDto> GetAllPaged(int count, int page);
        CategoryDto GetById(int id);
        CategoryDto Add(CategoryDto category);
        void Update(CategoryDto item);
        void Remove(int id);
        bool CheckName(string catename);
    }
}
