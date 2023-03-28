using System.ComponentModel.DataAnnotations;

namespace Next2Identity.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        public string? RoleId { get; set; }
        [Required(ErrorMessage = "Role name not found")]
        public string? RoleName { get; set; }
    }
}

