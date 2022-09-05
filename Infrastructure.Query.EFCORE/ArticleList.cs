using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.EFCORE.ContextDB;
using Infrastructure.Query.EFCORE.DTO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query.EFCORE
{
    public class ArticleList : IArticleList,IDisposable
    {
        private MasterContext _context { get; }

        public ArticleList(MasterContext context)
        {
            _context = context;
        }

        public List<ArticleQueryDTO>? getAll()
        {
            var result = _context.Articles.Include(x => x.ArticleCategory).Include(x => x.Comments)
                .Where(x => x.IsDeleted == false && x.ArticleCategory.IsDeleted == false).Select(x=>new ArticleQueryDTO
                {
                    ArticleCategoryTitle = x.ArticleCategory.Title,
                    CommentCount = x.Comments.Count(x=>x.Status== true),
                    Content = x.Content,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = x.Id,
                    ImageName = x.Image,
                    ShortDescription = x.ShortDescription,
                    Title = x.Title
                }).AsNoTracking().ToList();
            return result;
        }

        public ArticleQueryDTO GetArticle(string id)
        {
            var result = _context.Articles.Include(x => x.ArticleCategory).Include(x => x.Comments)
                .Where(x => x.Id == id).Select(x=>new ArticleQueryDTO
                {
                    ArticleCategoryTitle = x.ArticleCategory.Title,
                    CommentCount = x.Comments.Count(x => x.Status == true),
                    Content = x.Content,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Id = x.Id,
                    ImageName = x.Image,
                    ShortDescription = x.ShortDescription,
                    Title = x.Title,
                    Comment = x.Comments.Where(x=>x.Status==true).Select(c=>new CommentQueryDTO
                    {
                        CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
                        Message = c.Message,
                        Name = c.Name
                    }).ToList()
                }).AsNoTracking().FirstOrDefault();
            return result!;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
