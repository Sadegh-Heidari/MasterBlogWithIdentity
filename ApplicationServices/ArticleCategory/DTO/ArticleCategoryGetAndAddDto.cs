using System.ComponentModel.DataAnnotations;

namespace ApplicationServices.ArticleCategory.DTO
{
    public class ArticleCategoryGetAndAddDto:ArticleCategoryBaseDTO
    {
        [Required]
        public string Title { get; set; }
    }
}
