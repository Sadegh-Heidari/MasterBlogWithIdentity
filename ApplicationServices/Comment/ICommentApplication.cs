using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Comment.DTO;

namespace ApplicationServices.Comment
{
    public interface ICommentApplication
    {
        List<CommentListDTO> GetAllComments();
        void Confirm(string Id);
        void Cancel(string Id);
        void AddComment(string name, string email, string message, string articleId);
    }
}
