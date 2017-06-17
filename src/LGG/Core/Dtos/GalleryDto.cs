using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Dtos
{
    public class GalleryDto
    {
        public int GalleryId { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [MaxLengthAttribute(100, ErrorMessage = "khong dược dài quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [MaxLengthAttribute(255, ErrorMessage = "khong dược dài quá 100 ký tự")]
        public string Image { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
