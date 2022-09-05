using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleCategoryAgg;
using DomainServices.ArticleCategory;
using Infrastructure.EFCORE.Base;
using Infrastructure.EFCORE.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCORE.ArticleCategory
{
    public class ArticleCategoryRepository:BaseRepository<Domain.ArticleCategoryAgg.ArticleCategory>,IArticleCategoryRepository
    {
        public ArticleCategoryRepository(MasterContext context) : base(context)
        {
        }

        public Domain.ArticleCategoryAgg.ArticleCategory? GetById(string id)
        {
            var result = _context.ArticleCateogries.FirstOrDefault(c => c.Id == id);
            return result;
        }

        public List<T> GetTitleCategory<T>() where T : IGetArticleCategoryTitle, new()
        {
            var result = _context.ArticleCateogries.Where(x => x.IsDeleted == false).AsNoTracking().Select(x => new T
            {
                Id = x.Id,
                Title = x.Title,
            }).ToList();
            return result;
        }
    }
}
