using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Areas.Admin.Pages.ViewModels
{
    public class ArticleCategoryViewModel:IDisposable
    {
        public string? Id { get; set; }
        [Required]
        public string? Title { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
