using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Article;
using Infrastructure.EFCORE.Base;
using Infrastructure.EFCORE.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCORE.Article
{
    public class ArticleRepository:BaseRepository<Domain.ArticleAgg.Article>,IArticleRepository
    {
        public ArticleRepository(MasterContext context) : base(context)
        {
        }


        public List<T> GetListWithFilter<T>() where T : IArticleListViewModel,new()
        {
            var result = _context.Articles.Include(x => x.ArticleCateogry).Select(x => new T
            {
                Title = x.Title,
                ArticleCategoryTitle = x.ArticleCateogry.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return result;
        }
    }
}
