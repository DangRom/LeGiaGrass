using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{

    [Table("Tags")]
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        [StringLength(100)]
        public string Url { get; set; }

        public IList<PostTag> Posts { get; set; }
    }
}
