using System;
using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using System.Data;
using Dapper;

namespace LeGiaGrass.Services.Repository{
    public class CategoryRepository : RepositoriesBase<CategoryModel>, ICategoryRepository
    {
        public bool CheckAlias(string alias)
        {
            var para = new DynamicParameters();
            para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
            return CheckRecord("findCategoryByAlias", para);
        }

        public void Delete(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            Execute("deleteCategory", para);
        }

        public IEnumerable<CategoryModel> GetAllCategory()
        {
            return GetAll("getAllCategory", null);
        }

      public IEnumerable<CategoryModel> GetAllCategoryForPost()
      {
         return GetAll("getAllCategoryForPost", null);
      }

      public CategoryModel GetCategoryById(int id)
        {
            var para = new DynamicParameters();
            para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
            return GetById("getCategoryById", para);
        }

      public IEnumerable<CategoryModel> GetCategoryForMenuHead()
      {
            return GetAll("getMenuHead", null);
      }

      public void Insert(CategoryModel model)
        {
            var para = GetParams(model);
            Execute("insertCategory", para);
        }

        public void Update(CategoryModel model)
        {
            var para = GetParams(model);
            para.Add("pId", model.Id, DbType.Int32, ParameterDirection.Input);
            Execute("updateCategory", para);
        }

        private DynamicParameters GetParams(CategoryModel model){
            var para = new DynamicParameters();
            para.Add("pName", model.Name, DbType.String, ParameterDirection.Input);
            para.Add("pAlias", model.Alias, DbType.String, ParameterDirection.Input);
            para.Add("pImage", model.Image, DbType.String, ParameterDirection.Input);
            para.Add("pDescriptions", model.Descriptions, DbType.String, ParameterDirection.Input);
            para.Add("pContent", model.Content, DbType.String, ParameterDirection.Input);
            para.Add("pActivated", model.Activated, DbType.Boolean, ParameterDirection.Input);
            para.Add("pService", model.Service, DbType.Boolean, ParameterDirection.Input);
            para.Add("pOrders", model.Orders, DbType.Int32, ParameterDirection.Input);
            return para;
        }
    }
}