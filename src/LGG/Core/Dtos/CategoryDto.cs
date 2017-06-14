using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "không được bỏ trống")]
        [MaxLength(100, ErrorMessage = "không được dài quá 100 ký tự")]

        public string Name { get; set; }

        [MaxLength(255, ErrorMessage = "khong duoc dai qua 255 ký tu")]
        public string Url { get; set; }


    }
}
