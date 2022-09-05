using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Comment;

namespace ApplicationServices.Comment.DTO
{
    public class CommentListDTO:ICommentListDTO
    {
        public string? Name { get; set; }
        public string? ArticleTitle { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool? Status { get; set; }
        public string? Id { get; set; }
        public string? CreationDate { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
