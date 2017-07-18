using System.ComponentModel.DataAnnotations;

namespace LeGiaGrass.Areas.Admin.Models{
    public class ServiceViewModel{
        public int Id { get; set; }

        [Required(ErrorMessage = "không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "không được bỏ trống")]
        [MaxLength(255, ErrorMessage = "không được dài quá 255 ký tự")]
        public string Alias { get; set; }

        [Required(ErrorMessage = "không dược bỏ trống")]
        [MaxLength(255, ErrorMessage = "không dược dài quá 255 ký tự")]
        public string Image { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public bool Activated { get; set; }
    }
}