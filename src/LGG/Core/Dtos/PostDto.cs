using System;
using System.Collections.Generic;

namespace LGG.Core.Dtos
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public string Url { get; set; }

        public string Link { get; set; }
        public string Meta { get; set; }


        public string Image { get; set; }
        public string SmallImage { get; set; }
        public string IconImage { get; set; }

        public DateTime PostedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool Published { get; set; }

        public IEnumerable<TagDto> Tags { get; set; }
        public ArticleDto Article { get; set; }
        public CategoryDto Category { get; set; }
        public ExcerptDto Excerpt { get; set; }

        public PostDto()
        {
            Tags = new List<TagDto>();
            Category = new CategoryDto();
            Article = new ArticleDto();
            Excerpt = new ExcerptDto();
        }
    }
}
