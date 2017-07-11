using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface IServiceRepository : IRepositoriesBase<ServiceModel>{
        void Insert(ServiceModel model);
        void Update(ServiceModel model);
        void Delete(int id);
        bool CheckAlias(string alias);
        ServiceModel GetServiceById(int id);
        ServiceModel GetServiceByAlias(string alias);
        IEnumerable<ServiceModel> GetAllService();
        IEnumerable<ServiceModel> GetAllServiceForFeedback();
        IEnumerable<ServiceModel> GetAllServiceForHomePage();
        IEnumerable<ServiceModel> GetAllServiceForMenuLine();
        IEnumerable<ServiceModel> GetForFooter();
    }
}