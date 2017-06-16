using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Url { get; set; }

        public ICollection<Post> Posts { get; set; }

        // public ICollection<Gallery> Galleries { get; set; }
    }
}
