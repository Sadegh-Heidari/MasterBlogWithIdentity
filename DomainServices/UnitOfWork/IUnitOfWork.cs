using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Article;
using DomainServices.ArticleCategory;
using DomainServices.Comment;

namespace DomainServices.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IArticleCategoryRepository ArticleCategoryRepository { get;  }
        public IArticleRepository ArticleRepository { get; }
        public ICommentRepository CommentRepository { get; }
        void SaveChanges();
        void Dispose();
    }
}
