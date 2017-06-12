using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using System.Collections.Generic;
using System.Linq;

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
        /// Get all tags
        /// </summary>
        /// <returns>Collection of tags</returns>
        public IEnumerable<CompanyDto> GetAll(bool includeAbout = true, bool includePrivacy = true, bool includeTermsOfUse = true)
        {
            return _companyRepository.GetAll(includeAbout, includePrivacy, includeTermsOfUse)
                .Select(Mapper.Map<Company, CompanyDto>)
                .OrderBy(x => x.Name)
                .ToList();
        }


        /// <summary>
        /// Get Company by id
        /// </summary>
        /// <param name="id">Company id</param>
        /// <returns>Company Object</returns>
        public CompanyDto GetById(int id)
        {
            return Mapper.Map<Company, CompanyDto>(_companyRepository.GetById(id));
        }

        /// <summary>
        /// Create Company record
        /// If a Name is not provided, set Name and URL to a GUID
        /// </summary>
        /// <param name="company">company</param>
        public CompanyDto Add(CompanyDto company)
        {
            if (company.Name == null)
            {
                company.Name = "Default Company Name";
            }

            var response = _companyRepository.Add(Mapper.Map<CompanyDto, Company>(company));
            company.Id = response.Id;
            return company;
        }

        /// <summary>
        /// Update Company record
        /// </summary>
        /// <param name="company">Updated Company</param>
        public void Update(CompanyDto company)
        {
            _companyRepository.Update(company);
        }

        /// <summary>
        /// Delete Company record based on id
        /// </summary>
        /// <param name="id">Company Id</param>
        public void Remove(int id)
        {
            _companyRepository.Remove(id);
        }

        /// <summary>
        /// Get paged collection of Companies
        /// </summary>
        /// <param name="count">Number of tags in page</param>
        /// <param name="page">Page of Companies</param>
        /// <returns>Count of Companies starting at page</returns>
        public IEnumerable<CompanyDto> GetAllPaged(int count = 10, int page = 1)
        {
            return _companyRepository.GetAllPaged(count, page).Select(Mapper.Map<Company, CompanyDto>);
        }

        public CompanyDto GetCompanyFirstOrDefault(bool includeAbout, bool includePrivacy, bool includeTermsOfUse)
        {
            return Mapper.Map<Company, CompanyDto>(_companyRepository.GetCompanyFirstOrDefault(includeAbout, includePrivacy, includeTermsOfUse));
        }
    }
}
