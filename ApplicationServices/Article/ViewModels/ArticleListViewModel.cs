using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Article;

namespace ApplicationServices.Article.ViewModels
{
    public class ArticleListViewModel: IArticleListViewModel,IDisposable
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
