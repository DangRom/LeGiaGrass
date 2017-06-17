using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [MaxLengthAttribute(100, ErrorMessage = "khong dược dài quá 100 ký tự")]

        public string Name { get; set; }

        [Required(ErrorMessage = "không được để trống")]
        [MaxLengthAttribute(255, ErrorMessage = "khong dược dài quá 100 ký tự")]

        public string Url { get; set; }


    }
}
