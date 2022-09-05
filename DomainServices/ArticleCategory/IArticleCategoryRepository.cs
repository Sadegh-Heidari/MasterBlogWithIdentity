using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using DomainServices.Base;

namespace DomainServices.ArticleCategory
{
    public interface IArticleCategoryRepository : IBaseRepository<Domain.ArticleCategoryAgg.ArticleCategory>
    {
        Domain.ArticleCategoryAgg.ArticleCategory? GetById(string id);
        List<T> GetTitleCategory<T>() where T : IGetArticleCategoryTitle, new();
    }
}
