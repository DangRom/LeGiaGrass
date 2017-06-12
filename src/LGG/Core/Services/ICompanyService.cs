using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface ICompanyService
    {
        CompanyDto GetCompanyFirstOrDefault(bool includeAbout, bool includePrivacy, bool includeTermsOfUse); /* Mặc định chỉ có một công ty trên site */

        ////CompanyDto Add(CompanyDto post); /* Không thể thêm mới*/
        //void Update(CompanyDto item);  /* Chỉ cập nhật thông tin công ty hiện tại */
        ////void Remove(string id); /* Không thể Remove */


        IEnumerable<CompanyDto> GetAll(bool includeAbout = true, bool includePrivacy = true, bool includeTermsOfUse = true);
        IEnumerable<CompanyDto> GetAllPaged(int count, int page = 1);
        CompanyDto GetById(int id);
        CompanyDto Add(CompanyDto tag);
        void Update(CompanyDto tag);
        void Remove(int id);
    }
}
