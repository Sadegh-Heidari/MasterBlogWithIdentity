using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.ArticleCategory.ViewModel
{
    public class ArticleCategoryBaseViewModel:IDisposable
    {
        public string? Id { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDeleted { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
