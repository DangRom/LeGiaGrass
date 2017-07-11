using System;
using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using System.Data;
using Dapper;

namespace LeGiaGrass.Services.Repository{
    public class ServiceRepository : RepositoriesBase<ServiceModel>, IServiceRepository
    {
        public bool CheckAlias(string alias)
        {
            var para = new DynamicParameters();
            para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
            return CheckRecord("findServiceByAlias", para);
        }

        public void Delete(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            Execute("deleteService", para);
        }

        public IEnumerable<ServiceModel> GetAllService()
        {
            return GetAll("getAllService", null);
        }

        public ServiceModel GetServiceById(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            return GetById("getServiceById", para);
        }

        public ServiceModel GetServiceByAlias(string alias)
        {
            var para = new DynamicParameters();
            para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
            return GetById("getServiceByAlias", para);
        }

        public void Insert(ServiceModel model)
        {
            var para = GetParams(model);
            Execute("insertService", para);
        }

        public void Update(ServiceModel model)
        {
            var para = GetParams(model);
            para.Add("pId", model.Id, DbType.Int32, ParameterDirection.Input);
            Execute("updateService", para);
        }

        public IEnumerable<ServiceModel> GetAllServiceForFeedback()
        {
            return GetAll("getAllServiceForFeedback", null);
        }

        public IEnumerable<ServiceModel> GetAllServiceForHomePage()
        {
            return GetAll("getAllServiceForHomePage", null);
        }

          public IEnumerable<ServiceModel> GetAllServiceForMenuLine()
        {
            return GetAll("getAllServiceForMenuLine", null);
        }

        public IEnumerable<ServiceModel> GetForFooter()
        {
            return GetAll("getServiceForFooter", null);
        }

        public DynamicParameters GetParams(ServiceModel model){
            var para = new DynamicParameters();
            para.Add("pName", model.Name, DbType.String, ParameterDirection.Input);
            para.Add("pAlias", model.Alias, DbType.String, ParameterDirection.Input);
            para.Add("pImage", model.Image, DbType.String, ParameterDirection.Input);
            para.Add("pPrice", model.Price, DbType.Int32, ParameterDirection.Input);
            para.Add("pStatus", model.Status, DbType.String, ParameterDirection.Input);
            para.Add("pShortDescription", model.ShortDescription, DbType.String, ParameterDirection.Input);
            para.Add("pContent", model.Content, DbType.String, ParameterDirection.Input);
            para.Add("pActivated", model.Activated, DbType.Boolean, ParameterDirection.Input);
            return para;
        }
   }
}