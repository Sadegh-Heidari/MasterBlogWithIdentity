using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Article;
using DomainServices.ArticleCategory;

namespace DomainServices.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IArticleCategoryRepository ArticleCategoryRepository { get;  }
        public IArticleRepository ArticleRepository { get; }
        void SaveChanges();
        void Dispose();
    }
}
