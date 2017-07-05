using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Models
{
    public class Testimonial
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [StringLength(50)]
        public string Position { get; set; }

        [Required]
        [MaxLength(200)]
        [StringLength(200)]
        public string Content { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string SmallImage { get; set; }
    }
}
