using System.ComponentModel.DataAnnotations;

namespace LeGiaGrass.Areas.Admin.Models{
    public class CompanyViewModel{
        [Required(ErrorMessage = "không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Address { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Email { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Hotline { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Phone { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string TaxCode { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Google { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Twitter { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Facebook { get; set; }

        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Description { get; set; }

        public string About { get; set; }

        [MaxLength(255, ErrorMessage = "Không được dài quá 255 ký tự")]
        public string Sologan { get; set; }

        [MaxLength(255, ErrorMessage = "Không được dài quá 255 ký tự")]
        public string BusinessHours { get; set; }
    }
}