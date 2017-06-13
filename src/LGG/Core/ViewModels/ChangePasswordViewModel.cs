using System.ComponentModel.DataAnnotations;

namespace LGG.Core.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} cần ít nhất {2} ký tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận lại mật khẩu mới")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới không khớp khi gõ xác nhận lại.")]
        public string ConfirmPassword { get; set; }
    }
}
