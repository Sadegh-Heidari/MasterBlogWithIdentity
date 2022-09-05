using ApplicationServices.Article;
using ApplicationServices.Article.DTO;
using Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.Article
{
    public class IndexModel : PageModel
    {
        public List<ArticleListDto>? ArticleListViewModels { get; set; }
        private IArticleApplication _articleApplication { get; }

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            ArticleListViewModels = _articleApplication.getList();
        }
        public IActionResult OnPostActive(string Id)
        {
            _articleApplication.ActiveArticle(Id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostRemove(string Id)
        {
            _articleApplication.DeleteArticle(Id);
            return RedirectToPage("./Index");
        }
    }
}
