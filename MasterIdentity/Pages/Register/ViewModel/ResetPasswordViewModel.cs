using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Pages.Register.ViewModel
{
    public class ResetPasswordViewModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
