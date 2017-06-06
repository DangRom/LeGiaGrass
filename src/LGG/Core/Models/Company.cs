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

        public int AboutId { get; set; }
        public int PrivacyId { get; set; }
        public int TermsOfUseId { get; set; }

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

        /* Navigation */
        public Article ArticleAbout { get; set; }
        public Article ArticlePrivacy { get; set; }
        public Article ArticleTermsOfUse { get; set; }
    }
}
