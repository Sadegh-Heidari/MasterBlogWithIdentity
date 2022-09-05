using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterIdentity.Areas.Admin.Pages.ViewModels
{
    public class ArticleViewModel : IDisposable
    {
        public string? Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public string? ShortDescription { get; set; }
        public string? ImageName { get; set; }
        [Required]
        public string? ArticleCategoryId { get; set; }
        public List<SelectListItem>? CategoryItem { get; set; }
        public string? SelectedCategoryItem { get; set; }
        [Required]
        public IFormFile? UploadFile { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
