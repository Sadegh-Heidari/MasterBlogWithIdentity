using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Pages.ViewModel
{
    public class CommentViewModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
       public string? Email { get; set; }
       [Required]
       public string? Message { get; set; }
       public string? ArticleId { get; set; }
    }
}
