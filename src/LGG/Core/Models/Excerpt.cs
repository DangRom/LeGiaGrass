using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{
    [Table("Excerpts")]
    public class Excerpt
    {
        [Key]
        public int ExcerptId { get; set; }

        [Display(Name = "Excerpt")]
        [StringLength(500)]
        public string Content { get; set; }
    }
}
