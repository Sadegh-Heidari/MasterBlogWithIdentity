using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.ArticleCategory.ViewModel
{
    public class ArticleCategoryGetAndAddViewModel:ArticleCategoryBaseViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
