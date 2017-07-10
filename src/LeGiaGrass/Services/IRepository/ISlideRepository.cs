using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface ISlideRepository : IRepositoriesBase<SlideModel>{
        void Insert(SlideModel model);
        void Update(SlideModel model);
        void Delete(int id);
        bool CheckAlias(string alias);
        SlideModel GetSlideById(int id);
        IEnumerable<SlideModel> GetAllSlide();
        IEnumerable<SlideModel> GetAllSlideForHome();
    }
}