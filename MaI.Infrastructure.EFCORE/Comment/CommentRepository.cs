using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Comment;
using Infrastructure.EFCORE.Base;
using Infrastructure.EFCORE.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCORE.Comment
{
    public class CommentRepository:BaseRepository<Domain.CommentAgg.Comment>,ICommentRepository
    {
        public CommentRepository(MasterContext context) : base(context)
        {
        }

        public List<T> GetComment<T>() where T : ICommentListDTO, new()
        {
            var result = _context.Comments.AsNoTracking().Select(x => new T
            {
                ArticleTitle = x.Article.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                Email = x.Email,
                Id = x.Id,
                Message = x.Message,
                Name = x.Name,
                Status = x.Status
            }).ToList();
            return result;
        }

        public Domain.CommentAgg.Comment? GetComment(string id)
        {
            var result = _context.Comments.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
