using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Comment
{
    public interface ICommentListDTO:IDisposable
    {
        public string? Name { get; set; }
        public string? ArticleTitle { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public bool? Status { get; set; }
        public string? Id { get; set; }
        public string? CreationDate { get; set; }
    }
}
