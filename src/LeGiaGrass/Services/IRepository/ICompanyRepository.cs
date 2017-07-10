using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LeGiaGrass.Services.InfactStructure;
using LeGiaGrass.Services.Models;

namespace LeGiaGrass.Services.IRepository
{
    public interface ICompanyRepository : IRepositoriesBase<CompanyModel>{
        CompanyModel GetCompany();
        void SaveCompany(CompanyModel model);
        CompanyModel GetCompanyForHome();
        CompanyModel GetCompanyForHead();
        CompanyModel GetCompanyForFooter();
    }
}
