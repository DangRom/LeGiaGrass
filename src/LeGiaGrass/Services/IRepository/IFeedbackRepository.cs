using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository{
    public interface IFeedbackRepository : IRepositoriesBase<FeedbackModel>{
        void Insert(FeedbackModel model);
        void Update(FeedbackModel model);
        void Delete(int id);
        FeedbackModel GetFeedbackById(int id);
        IEnumerable<FeedbackModel> GetAllFeedbank();   
        IEnumerable<FeedbackModel> GetAllFeedbackForHomePage(); 
    }
}