using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Pages.Register.ViewModel
{
    public class LogInViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool IsPersistance { get; set; } = false;
    }
}
