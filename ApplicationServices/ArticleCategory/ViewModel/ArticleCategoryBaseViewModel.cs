using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.ArticleCategory.ViewModel
{
    public class ArticleCategoryBaseViewModel:IDisposable
    {
        public string Id { get; set; }
        public string CreationDate { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
