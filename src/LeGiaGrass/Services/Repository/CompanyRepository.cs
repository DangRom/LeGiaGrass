﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.IRepository;
using LeGiaGrass.Services.Models;
using System.Data;
using Dapper;

namespace LeGiaGrass.Services.Repository
{
    public class CompanyRepository : RepositoriesBase<CompanyModel>, ICompanyRepository
    {
        public CompanyModel GetCompany(){
            return GetById("getCompany", null);
        }

      public CompanyModel GetCompanyForFooter()
      {
         return GetById("getCompanyForFooter", null);
      }

      public CompanyModel GetCompanyForHead()
      {
         return GetById("getCompanyForHead", null);
      }

      public CompanyModel GetCompanyForHome()
      {
         return GetById("getCompanyForHome", null);
      }

      public void SaveCompany(CompanyModel model)
        {
            var para = new DynamicParameters();
            para.Add("pName", model.Name, DbType.String, ParameterDirection.Input);
            para.Add("pAddress", model.Address, DbType.String, ParameterDirection.Input);
            para.Add("pEmail", model.Email, DbType.String, ParameterDirection.Input);
            para.Add("pPhone", model.Phone, DbType.String, ParameterDirection.Input);
            para.Add("pHotline", model.Hotline, DbType.String, ParameterDirection.Input);
            para.Add("pTaxCode", model.TaxCode, DbType.String, ParameterDirection.Input);
            para.Add("pGoogle", model.Google, DbType.String, ParameterDirection.Input);
            para.Add("pTweeter", model.Tweeter, DbType.String, ParameterDirection.Input);
            para.Add("pFacebook", model.Facebook, DbType.String, ParameterDirection.Input);
            para.Add("pDescription", model.Description, DbType.String, ParameterDirection.Input);
            para.Add("pAbout", model.About, DbType.String, ParameterDirection.Input);
            Execute("updateCompany", para);
        }
    }
}