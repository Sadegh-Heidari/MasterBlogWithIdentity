using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.Article
{
    public interface IArticleListDTO
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? ArticleCategoryTitle { get; set; }
        public bool IsDeleted { get; set; }
        public string? CreationDate { get; set; }
    }
}
