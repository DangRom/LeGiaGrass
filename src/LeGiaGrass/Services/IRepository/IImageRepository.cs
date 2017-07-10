using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface IImageRepository: IRepositoriesBase<ImageModel>{
       void Insert(ImageModel model);
       void Update(ImageModel model);
       void Delete(int id);
       ImageModel GetImageById(int id);
       IEnumerable<ImageModel> GetAllImage();
       IEnumerable<ImageModel> GetAllImageForHomePage();
       IEnumerable<ImageModel> GetAllCustomerForHomePage();
    }
}