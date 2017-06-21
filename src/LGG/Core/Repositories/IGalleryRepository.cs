using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;

namespace LGG.Core.Repositories
{
    public interface IGalleryRepository
    {
        IEnumerable<Gallery> GetAll();
        IEnumerable<Gallery> GetAllPaged(int count, int page);
        Gallery GetById(int id);
        IEnumerable<Gallery> GetByCategoryName(string categoryName);
        void Add(Gallery gallery);
        void Update(GalleryDto gallery);
        void Remove(int id);
        bool CheckName(string name);
    }
}
