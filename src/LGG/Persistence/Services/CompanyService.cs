using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;

namespace LGG.Persistence.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        /// <summary>
        /// Return CompanyDto
        /// </summary>
        /// <returns></returns>
        public CompanyDto GetCompanyFirstOrDefault()
        {
            return Mapper.Map<Company, CompanyDto>(_companyRepository.GetCompanyFirstOrDefault());
        }

        /// <summary>
        /// Update Company Record
        /// </summary>
        /// <param name="company">CompanyDto Object</param>
        public void Update(CompanyDto company)
        {
            _companyRepository.Update(company);
        }
    }
}
