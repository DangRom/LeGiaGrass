﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LGG.Core.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [MaxLength(250)]
        [StringLength(250)]
        public string Title { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Meta { get; set; }

        [MaxLength(300)]
        [StringLength(300)]
        public string Description { get; set; }

        [MaxLength(220)]
        [StringLength(220)]
        public string Url { get; set; }

        [MaxLength(220)]
        [StringLength(220)]
        public string Link { get; set; }

        public bool Published { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string Image { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string SmallImage { get; set; }

        [MaxLength(250)]
        [StringLength(250)]
        public string IconImage { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Posted On")]
        public DateTime? PostedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        public int? ExcerptId { get; set; }

        public int? ArticleId { get; set; }

        public int? CategoryId { get; set; }

        public Excerpt Excerpt { get; set; }

        public Article Article { get; set; }

        public Category Category { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}
