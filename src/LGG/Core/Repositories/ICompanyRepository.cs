using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;

namespace LGG.Core.Repositories
{
    public interface ICompanyRepository
    {
        Company GetCompanyFirstOrDefault(bool includeAbout, bool includePrivacy, bool includeTermsOfUse); /* Mặc định chỉ có một công ty trên site */

        ////Company Add(Company map);/* Không thể thêm mới*/
        //void Update(CompanyDto company);/* Chỉ cập nhật thông tin công ty hiện tại */
        ////void Remove(string id);//void Remove(string id); /* Không thể Remove */

        IEnumerable<Company> GetAll(bool includeAbout, bool includePrivacy, bool includeTermsOfUse);
        IEnumerable<Company> GetAllPaged(int count, int page);
        Company GetById(int id);
        Company Add(Company tag);
        void Update(CompanyDto tag);
        void Remove(int id);
    }
}
