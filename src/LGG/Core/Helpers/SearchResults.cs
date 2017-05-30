using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Helpers
{
    public class SearchResults
    {

        public List<PostDto> Posts { get; set; }
        public int TotalMatchingPosts { get; set; }

        public SearchResults()
        {
            Posts = new List<PostDto>();
            // TODO: This should be set to 0 by default.  There currently is a bug in the Pioneer.Pagination service. 
            TotalMatchingPosts = 1;
        }
    }
}
