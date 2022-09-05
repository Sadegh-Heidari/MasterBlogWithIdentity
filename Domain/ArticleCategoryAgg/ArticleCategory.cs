using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleAgg;
using Domain.BaseDomainAgg;

namespace Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase
    {
        public string Title { get; private set; }
        public bool IsDeleted { get; private set; }
        public ICollection<Article> Articles { get; private set; }

        protected ArticleCategory()
        {
        }

        public ArticleCategory(string title)
        {
            Title = title;
            IsDeleted = false;
        }

        public void DeleteArticleCategory()
        {
            IsDeleted = true;
        }
        public void ActiveArticleCategory()
        {
            IsDeleted = false;
        }

        public void EditTitle(string title)
        {
            Title = title;
        }
    }
}
