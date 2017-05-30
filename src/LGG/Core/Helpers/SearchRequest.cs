using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Helpers
{
    public class SearchRequest
    {
        [Required]
        public string Query { get; set; }

        public int Page { get; set; }

        public SearchRequest()
        {
            Page = 1;
        }

    }
}
