﻿using System.ComponentModel.DataAnnotations;

namespace LGG.Core.Dtos
{
    public class TagDto
    {
        public int TagId { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [MaxLength(100, ErrorMessage = "khong duoc dai qua 100 ky tu")]
        public string Name { get; set; }

        public string Url { get; set; }
    }
}
