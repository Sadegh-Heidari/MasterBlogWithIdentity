using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Pages.Register.ViewModel
{
    public class ForGetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
