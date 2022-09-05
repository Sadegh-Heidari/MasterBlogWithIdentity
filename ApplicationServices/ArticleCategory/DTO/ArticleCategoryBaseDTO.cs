namespace ApplicationServices.ArticleCategory.DTO
{
    public class ArticleCategoryBaseDTO:IDisposable
    {
        public string? Id { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
