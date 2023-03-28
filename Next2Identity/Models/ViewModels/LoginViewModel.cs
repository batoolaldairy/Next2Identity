using System.ComponentModel.DataAnnotations;

namespace Next2Identity.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Your Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Enter Your password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
