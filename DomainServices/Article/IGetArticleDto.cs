namespace DomainServices.Article
{
    public interface IGetArticleDto:IDisposable
    {
        public string? Title { get; set; }
        public string? ShortDescription { get; set; }
        public string? Image { get; set; }
        public string? Content { get; set; }
    }
}
