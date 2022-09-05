using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Article;
using DomainServices.ArticleCategory;
using DomainServices.Comment;
using DomainServices.UnitOfWork;
using Infrastructure.EFCORE.Article;
using Infrastructure.EFCORE.ArticleCategory;
using Infrastructure.EFCORE.Comment;
using Infrastructure.EFCORE.ContextDB;

namespace Infrastructure.EFCORE.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private bool IsDisposed { get; set; }
        private IArticleCategoryRepository _articleCategoryRepository;
        private IArticleRepository _articleRepository;
        private ICommentRepository _commentRepository;
        private MasterContext _masterContext { get; }

        public UnitOfWork(MasterContext masterContext)
        {
            _masterContext = masterContext;
            IsDisposed = false;
        }

        public IArticleCategoryRepository ArticleCategoryRepository
        {
            get
            {
                if (_articleCategoryRepository == null)
                {
                    _articleCategoryRepository = new ArticleCategoryRepository(_masterContext);
                }
                return _articleCategoryRepository;
            }
        }

        public IArticleRepository ArticleRepository
        {
            get
            {
                if (_articleRepository == null)
                {
                    _articleRepository = new ArticleRepository(_masterContext);
                }

                return _articleRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_masterContext);
                }

                return _commentRepository;
            }
        }

        public void SaveChanges()
        {
            _masterContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool dis)
        {
            if(IsDisposed) return;
            if (!IsDisposed && dis && _masterContext != null)
            {
                _masterContext.Dispose();
                
            }
            IsDisposed = true;
        }

    }
}
