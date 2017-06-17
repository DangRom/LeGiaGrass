using LGG.Core.Models;

namespace LGG.Core.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public string VideoPresentation { get; set; }
        public string OurMission { get; set; }
        public string OurClients { get; set; }
        public string OurDifference1 { get; set; }
        public string OurDifference2 { get; set; }
        public string OurDifference3 { get; set; }
        public string OurDifference4 { get; set; }
        public string OurDifference5 { get; set; }
        public string WhyChooseUs { get; set; }

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

        public Article About { get; set; }
        public Article Privacy { get; set; }
        public Article TermsOfUse { get; set; }

        public CompanyDto()
        {
            About = new Article();
            Privacy = new Article();
            TermsOfUse = new Article();
        }
    }
}
