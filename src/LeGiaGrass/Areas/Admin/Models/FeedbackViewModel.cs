using System.ComponentModel.DataAnnotations;

namespace LeGiaGrass.Areas.Admin.Models{
    public class FeedbackViewModel{
        public int Id { get; set; }

        [Required(ErrorMessage = "không dược bỏ trống")]
        [MaxLength(255, ErrorMessage = "không dược dài quá 255 ký tự")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "không dược bỏ trống")]
        [MaxLength(255, ErrorMessage = "không dược dài quá 255 ký tự")]
        public string Avatar { get; set; }
        public string Content { get; set; }

        [Required(ErrorMessage = "không dược bỏ trống")]
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}