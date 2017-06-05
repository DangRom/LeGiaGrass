using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{
    [Table("Articles")]
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Display(Name = "Article"), StringLength(21844)]
        public string Content { get; set; }
    }
}
