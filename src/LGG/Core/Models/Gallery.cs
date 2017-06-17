using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{

    [Table("Galleries")]
    public class Gallery
    {
        [Key]
        public int GalleryId { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Name { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Description { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Image { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
