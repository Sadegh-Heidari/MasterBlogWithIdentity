using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Base;

namespace DomainServices.Article
{
    public interface IArticleRepository:IBaseRepository<Domain.ArticleAgg.Article>
    {
        List<T> GetListWithFilter<T>() where T : IArticleListViewModel,new();
    }
}
