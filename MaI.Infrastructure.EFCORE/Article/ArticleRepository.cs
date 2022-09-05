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


        public List<T> GetListWithSelect<T>() where T : IArticleListDTO,new()
        {
            var result = _context.Articles.Include(x=>x.ArticleCategory).Select(x => new T
            {
                Title = x.Title,
                ArticleCategoryTitle = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Id = x.Id,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return result;
        }

        public Domain.ArticleAgg.Article? GetById(string id)
        {
            var result = _context.Articles.FirstOrDefault(x => x.Id == id);
            return result;
        }

        public T? GetById<T>(string Id) where T : IGetArticleDto, new()
        {
            var result = _context.Articles.Where(x=>x.Id==Id).Select(x=>new T
            {
                Content = x.Content,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                Title = x.Title
            }).FirstOrDefault();
            return result;
        }
    }
}
