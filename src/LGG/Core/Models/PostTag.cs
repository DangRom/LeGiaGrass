using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{

    [Table("PostTags")]
    public class PostTag
    {
        [Key]
        public int PostTagId { get; set; }

        public int TagId { get; set; }

        public int PostId { get; set; }

        public Tag Tag { get; set; }

        public Post Post { get; set; }
    }
}
