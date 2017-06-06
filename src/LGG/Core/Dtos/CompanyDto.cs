using LGG.Core.Models;

namespace LGG.Core.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Sologan { get; set; }

        public string Hotline { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string TimeWork { get; set; }

        public string Address { get; set; }

        public string Logo { get; set; }

        public string Avatar { get; set; }

        public int AboutId { get; set; }
        public int PrivacyId { get; set; }
        public int TermsOfUseId { get; set; }

        public string Facebook { get; set; }

        public string Twitter { get; set; }

        public string Google { get; set; }

        public string LinkedIn { get; set; }

        public string Instagram { get; set; }

        public string Pinterest { get; set; }

        public Article ArticleAbout { get; set; }
        public Article ArticlePrivacy { get; set; }
        public Article ArticleTermsOfUse { get; set; }

        public CompanyDto()
        {
            ArticleAbout = new Article();
            ArticlePrivacy = new Article();
            ArticleTermsOfUse = new Article();
        }
    }
}
