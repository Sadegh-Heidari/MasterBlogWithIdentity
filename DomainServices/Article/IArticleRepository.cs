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
        List<T> GetListWithSelect<T>() where T : IArticleListDTO,new();
        Domain.ArticleAgg.Article? GetById(string id);
        T GetById<T>(string Id) where T:IGetArticleDto , new();
    }
}
