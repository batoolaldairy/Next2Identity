using System.ComponentModel.DataAnnotations;

namespace Next2Identity.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Enter Your Name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Enter Your Email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Enter Your password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = " Confirm and Password not match")]
        public string? ConfirmPassword { get; set; }
        public string? Phone { get; set; }
    }
}
