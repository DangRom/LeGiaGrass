using System;
using System.Collections.Generic;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using System.Data;
using Dapper;

namespace LeGiaGrass.Services.Repository{
   public class PostRepository : RepositoriesBase<PostModel>, IPostRepository
   {
      public bool CheckAlias(string alias)
      {
         var para = new DynamicParameters();
         para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
         return CheckRecord("findPostByAlias", para);
      }

      public void Delete(int id)
      {
         var para = new DynamicParameters();
         para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
         Execute("deletePost", para);
      }
      public IEnumerable<PostModel> getAllPostByCategoryByAlias(string alias)
      {
          var para = new DynamicParameters();
         para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
         return GetAll("getAllPostByCategoryByAlias", para);
      }
      public IEnumerable<PostModel> GetAllPost()
      {
         return GetAll("getAllPost", null);
      }

      public IEnumerable<PostModel> GetForFooter()
      {
         return GetAll("getPostForFooter", null);
      }

      public IEnumerable<PostModel> GetMenuLine()
      {
         return GetAll("getAllPostForMenuLine", null);
      }

      public PostModel GetPostById(int id)
      {
         var para = new DynamicParameters();
         para.Add("pId", id, DbType.Int32, ParameterDirection.Input);
         return GetById("getPostById", para);
      }

      public PostModel GetPostByAlias(string alias)
      {
         var para = new DynamicParameters();
         para.Add("pAlias", alias, DbType.String, ParameterDirection.Input);
         return GetById("getPostByAlias", para);
      }

      public IEnumerable<PostModel> GetPostForHomePage()
      {
         return GetAll("getPostForHome", null);
      }

      public void Insert(PostModel model)
      {
         var para = GetParams(model);
         Execute("insertPost", para);
      }

      public void Update(PostModel model)
      {
         var para = GetParams(model);
         para.Add("pId", model.Id, DbType.Int32, ParameterDirection.Input);
         Execute("updatePost", para);
      }

        public IEnumerable<PostModel> GetNewPostByCategory(int cateId)
        {
            var para = new DynamicParameters();
            para.Add("pCategoryId", cateId, DbType.Int32, ParameterDirection.Input);
            return GetAll("getNewPostOfCategoryId", para);
        }

      private DynamicParameters GetParams(PostModel model){
         var para = new DynamicParameters();
         para.Add("pName", model.Name, DbType.String, ParameterDirection.Input);
         para.Add("pAlias", model.Alias, DbType.String, ParameterDirection.Input);
         para.Add("pImage", model.Image, DbType.String, ParameterDirection.Input);
         para.Add("pShortDescription", model.ShortDescription, DbType.String, ParameterDirection.Input);
         para.Add("pActivated", model.Activated, DbType.Boolean, ParameterDirection.Input);
         para.Add("pContent", model.Content, DbType.String, ParameterDirection.Input);
         para.Add("pCategoryId", model.CategoryId, DbType.Int32, ParameterDirection.Input);
         para.Add("pHomePage", model.HomePage, DbType.Boolean, ParameterDirection.Input);
         para.Add("pCreateDate", model.CreateDate, DbType.DateTime, ParameterDirection.Input);
         return para;
      }

    }
}