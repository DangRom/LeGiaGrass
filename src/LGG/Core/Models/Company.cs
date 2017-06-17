using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        public string Name { get; set; }

        [MaxLength(500)]
        [StringLength(500)]
        public string Description { get; set; }


        [MaxLength(250)]
        [StringLength(250)]
        public string VideoPresentation { get; set; }

        [MaxLength(250)]
        [StringLength(250)]

        public string OurMission { get; set; }
        [MaxLength(250)]
        [StringLength(250)]
        public string OurClients { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string OurDifference1 { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string OurDifference2 { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string OurDifference3 { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string OurDifference4 { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string OurDifference5 { get; set; }

        [MaxLength(1000)]
        [StringLength(1000)]
        public string WhyChooseUs { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Sologan { get; set; }

        [MaxLength(15)]
        [StringLength(15)]
        public string Hotline { get; set; }

        [MaxLength(254)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Website { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string TimeWork { get; set; }

        [MaxLength(255)]
        [StringLength(255)]
        public string Address { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Logo { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Avatar { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Facebook { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Twitter { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Google { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string LinkedIn { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Instagram { get; set; }

        [MaxLength(50)]
        [StringLength(50)]
        public string Pinterest { get; set; }

        public int? AboutId { get; set; }
        public int? PrivacyId { get; set; }
        public int? TermsOfUseId { get; set; }

        /* Navigation */
        public Article About { get; set; }
        public Article Privacy { get; set; }
        public Article TermsOfUse { get; set; }
    }
}
