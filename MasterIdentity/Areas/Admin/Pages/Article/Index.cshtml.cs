using ApplicationServices.Article;
using ApplicationServices.Article.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.Article
{
    public class IndexModel : PageModel
    {
        public List<ArticleListViewModel>? ArticleListViewModels { get; set; }
        private IArticleApplication _articleApplication { get; }

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleListViewModels = _articleApplication.getList();
        }
    }
}
