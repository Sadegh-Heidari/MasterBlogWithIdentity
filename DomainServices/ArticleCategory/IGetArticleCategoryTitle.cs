using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices.ArticleCategory
{
    public interface IGetArticleCategoryTitle:IDisposable
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
