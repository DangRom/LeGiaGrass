using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using System.Data;
using Dapper;
using System;
using System.Collections.Generic;

namespace LeGiaGrass.Services.Repository{
    public class FeedbackRepository : RepositoriesBase<FeedbackModel>, IFeedbackRepository
    {
        public void Delete(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            Execute("deleteFeedback", para);
        }

      public IEnumerable<FeedbackModel> GetAllFeedbackForHomePage()
      {
            return GetAll("getAllFeedbackForHomePage", null);
      }

      public IEnumerable<FeedbackModel> GetAllFeedbank()
        {
            return GetAll("getAllFeedback", null);
        }

        public FeedbackModel GetFeedbackById(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            return GetById("getFeedbackById", para);
        }

        public void Insert(FeedbackModel model)
        {
            var para = GetParams(model);
            Execute("insertFeedback", para);
        }

        public void Update(FeedbackModel model)
        {
            var para = GetParams(model);
            para.Add("pId", model.Id, DbType.Int32, ParameterDirection.Input);
            Execute("updateFeedback", para);
        }

        private DynamicParameters GetParams(FeedbackModel model){
            var para = new DynamicParameters();
            para.Add("pFullName", model.FullName, DbType.String, ParameterDirection.Input);
            para.Add("pAvatar", model.Avatar, DbType.String, ParameterDirection.Input);
            para.Add("pContent", model.Content, DbType.String, ParameterDirection.Input);
            para.Add("pCreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
            para.Add("pServiceId", model.ServiceId, DbType.Int32, ParameterDirection.Input);
            return para;
        }
    }
}