using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Article.ViewModels;

namespace ApplicationServices.Article
{
    public interface IArticleApplication
    {
        List<ArticleListViewModel> getList();
    }
}
