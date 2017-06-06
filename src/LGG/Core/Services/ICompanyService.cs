using LGG.Core.Dtos;

namespace LGG.Core.Services
{
    public interface ICompanyService
    {
        CompanyDto GetCompanyFirstOrDefault(); /* Mặc định chỉ có một công ty trên site */
        //CompanyDto Add(CompanyDto post); /* Không thể thêm mới*/
        void Update(CompanyDto item);  /* Chỉ cập nhật thông tin công ty hiện tại */
        //void Remove(string id); /* Không thể Remove */
    }
}
