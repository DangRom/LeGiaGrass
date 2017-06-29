using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LGG.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Get all Companies
        /// </summary>
        /// <returns>Company Collection</returns>
        public IEnumerable<Company> GetAll(bool includeAbout, bool includePrivacy, bool includeTermsOfUse)
        {
            var query = _context
                      .Companies
                      .Where(x => true);

            if (includeAbout)
            {
                query = query.Include(x => x.About);
            }

            if (includePrivacy)
            {
                query = query.Include(x => x.Privacy);
            }

            if (includeTermsOfUse)
            {
                query = query.Include(x => x.TermsOfUse);
            }


            return query.ToList();
        }

        /// <summary>
        /// Get Company By Id
        /// </summary>
        /// <param name="id">Company Id</param>
        /// <returns>Company Entity</returns>
        public Company GetById(int id)
        {
            return _context
                    .Companies
                    .Include(x => x.About)
                    .Include(x => x.Privacy)
                    .Include(x => x.TermsOfUse)
                    .FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Create Company
        /// </summary>
        /// <param name="tagEntity">Company Entity to save</param>
        /// <returns>Company Entity with Id</returns>
        public Company Add(Company companyEntity)
        {
            _context
                .Companies
                .Add(companyEntity);
            _context.SaveChanges();

            return companyEntity;
        }

        /// <summary>
        /// Update Entity based on Model
        /// </summary>
        /// <param name="company">company Object</param>
        public void Update(CompanyDto company)
        {
            var entity = _context
                .Companies
                .Include(x => x.About)
                .Include(x => x.Privacy)
                .Include(x => x.TermsOfUse)
                .FirstOrDefault(x => x.Id == company.Id);

            entity.Name = company.Name;
            entity.Sologan = company.Sologan;
            entity.Hotline = company.Hotline;
            entity.Phone = company.Phone;
            entity.Email = company.Email;
            entity.ContactEmail = company.ContactEmail;
            entity.SupportEmail = company.SupportEmail;
            entity.Website = company.Website;
            entity.TimeWork = company.TimeWork;
            entity.Address = company.Address;
            entity.Logo = company.Logo;
            entity.Avatar = company.Avatar;
            entity.Description = company.Description;
            entity.WhyChooseUs = company.WhyChooseUs;


            entity.Facebook = company.Facebook;
            entity.Twitter = company.Twitter;
            entity.Google = company.Google;
            entity.LinkedIn = company.LinkedIn;
            entity.Instagram = company.Instagram;
            entity.Pinterest = company.Pinterest;

            // ArticleAbout
            entity.About.Content = company.About.Content;

            // ArticlePrivacy
            entity.Privacy.Content = company.Privacy.Content;

            // ArticleTermsOfUse
            entity.TermsOfUse.Content = company.TermsOfUse.Content;

            _context.SaveChanges();
        }

        /// <summary>
        /// Remove Company record based on Id
        /// </summary>
        /// <param name="id">Company Id</param>
        public void Remove(int id)
        {
            var entity = _context
                .Companies
                .FirstOrDefault(x => x.Id == id);

            _context.Companies.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a collection of Companies by skipping x and taking y
        /// </summary>
        /// <param name="count">The total number of Companies you want to Take</param>
        /// <param name="page">The denomination of Companies you want to skip. (page - 1) * count </param>
        /// <returns>Collections of Companies</returns>
        public IEnumerable<Company> GetAllPaged(int count, int page)
        {
            return _context
                    .Companies
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToList();
        }

        public Company GetCompanyFirstOrDefault(bool includeAbout, bool includePrivacy, bool includeTermsOfUse)
        {
            var query = _context
                    .Companies;

            if (includeAbout)
                query.Include(x => x.About);

            if (includePrivacy)
                query.Include(x => x.Privacy);

            if (includeTermsOfUse)
                query.Include(x => x.TermsOfUse);

            return query.FirstOrDefault();

        }

        public Company GetCompany()
        {
            return _context
                    .Companies
                    .Include(x => x.About)
                    .Include(x => x.Privacy)
                    .Include(x => x.TermsOfUse)
                    .FirstOrDefault();
        }
    }
}
