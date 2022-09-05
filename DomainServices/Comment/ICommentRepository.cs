using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainServices.Base;

namespace DomainServices.Comment
{
    public interface ICommentRepository:IBaseRepository<Domain.CommentAgg.Comment>
    {
        List<T> GetComment<T>() where T : ICommentListDTO, new();
        Domain.CommentAgg.Comment? GetComment(string id);
    }
}
