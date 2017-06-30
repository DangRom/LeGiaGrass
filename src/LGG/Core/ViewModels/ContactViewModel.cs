using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LGG.Core.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name = "Họ Tên Quý Khách")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(254)]
        //[EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string Email { get; set; }

        [Display(Name = "Điện Thoại")]
        //[Phone(ErrorMessage = "Số điện thoại không đúng")]
        public string Phone { get; set; }

        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        //[Required]
        [Display(Name = "Tiêu Đề")]
        public string Subject { get; set; }

        //[Required]
        [Display(Name = "Dịch Vụ")]
        public string Service { get; set; }
        public List<SelectListItem> ServiceSelectList { get; set; }

        [Required]
        [Display(Name = "Lời Nhắn")]
        public string Message { get; set; }
    }
}
