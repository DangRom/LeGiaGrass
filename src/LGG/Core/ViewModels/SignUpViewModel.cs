using System.ComponentModel.DataAnnotations;

namespace LGG.Core.ViewModels
{
    public class SignUpViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [StringLength(254)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
