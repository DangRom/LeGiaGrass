using LGG.Core.Dtos;
using LGG.Core.Models;

namespace LGG.Core.Repositories
{
    public interface ICompanyRepository
    {
        Company GetCompanyFirstOrDefault(); /* Mặc định chỉ có một công ty trên site */
        //Company Add(Company map);/* Không thể thêm mới*/
        void Update(CompanyDto company);/* Chỉ cập nhật thông tin công ty hiện tại */
        //void Remove(string id);//void Remove(string id); /* Không thể Remove */
    }
}
