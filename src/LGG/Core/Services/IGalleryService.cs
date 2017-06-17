using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface IGalleryService
    {
        IEnumerable<GalleryDto> GetAll();
        IEnumerable<GalleryDto> GetAllPaged(int count, int page);
        GalleryDto GetById(int id);
        void Add(GalleryDto gallery);
        void Update(GalleryDto item);
        void Remove(int id);
        bool CheckName(string name);
    }
}
