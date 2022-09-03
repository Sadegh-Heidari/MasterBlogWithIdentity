using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.ArticleCategory;

namespace DomainServices.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IArticleCategoryRepository ArticleCategoryRepository { get;  }
        void SaveChanges();
        void Dispose();
    }
}
