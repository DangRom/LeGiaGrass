using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Company GetCompanyFirstOrDefault()
        {
            return _context.Companies.FirstOrDefault();
        }

        public void Update(CompanyDto company)
        {
            var entity = _context
                .Companies
                .Include(x => x.ArticleAbout)
                .Include(x => x.ArticlePrivacy)
                .Include(x => x.ArticleTermsOfUse)
                .FirstOrDefault(x => x.Id == company.Id);

            entity.Name = company.Name;
            entity.Sologan = company.Sologan;
            entity.Hotline = company.Hotline;
            entity.Email = company.Email;
            entity.Website = company.Website;
            entity.TimeWork = company.TimeWork;
            entity.Address = company.Address;
            entity.Logo = company.Logo;
            entity.Avatar = company.Avatar;


            entity.Facebook = company.Facebook;
            entity.Twitter = company.Twitter;
            entity.Google = company.Google;
            entity.LinkedIn = company.LinkedIn;
            entity.Instagram = company.Instagram;
            entity.Pinterest = company.Pinterest;

            // ArticleAbout
            entity.ArticleAbout.Content = company.ArticleAbout.Content;

            // ArticlePrivacy
            entity.ArticlePrivacy.Content = company.ArticlePrivacy.Content;

            // ArticleTermsOfUse
            entity.ArticleTermsOfUse.Content = company.ArticleTermsOfUse.Content;


            _context.SaveChanges();
        }
    }
}
