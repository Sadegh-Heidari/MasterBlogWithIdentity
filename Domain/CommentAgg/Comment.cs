using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ArticleAgg;
using Domain.BaseDomainAgg;

namespace Domain.CommentAgg
{
    public class Comment:DomainBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Message { get; private set; }
        public bool? Status { get; private set; }
        public string ArticleId { get; private set; }
        public Article Article { get; private set; }

        protected Comment()
        {

        }
        public Comment(string name, string email, string message, string articleId)
        {
            Name = name;
            Email = email;
            Message = message;
            ArticleId = articleId;
            Status = null;
        }

        public void Confirm()
        {
            Status = true;
        }

        public void Cancel()
        {
            Status = false;
        }
    }
}
