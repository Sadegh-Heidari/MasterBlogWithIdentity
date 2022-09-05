using DomainServices.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.ArticleCategory.DTO
{
    public class GetArticleCategoryTitle: IGetArticleCategoryTitle
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
