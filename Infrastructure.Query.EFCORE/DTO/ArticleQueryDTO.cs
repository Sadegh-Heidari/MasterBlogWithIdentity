namespace Infrastructure.Query.EFCORE.DTO
{
    public class ArticleQueryDTO:IDisposable
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? ArticleCategoryTitle { get; set; }
        public string? ShortDescription { get; set; }
        public string? ImageName { get; set; }
        public string? CreationDate { get; set; }
        public string? Content { get; set; }
        public int CommentCount { get; set; }
        public List<CommentQueryDTO>? Comment { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}