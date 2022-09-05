using DomainServices.Article;

namespace ApplicationServices.Article.DTO
{
    public class ArticleListDto: IArticleListDTO,IDisposable
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? ArticleCategoryTitle { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreationDate { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
