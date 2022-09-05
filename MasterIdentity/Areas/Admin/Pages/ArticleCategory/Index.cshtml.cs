using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.ArticleCategory
{
    public class IndexModel : PageModel
    {
        
        public List<ArticleCategoryGetAndAddDto>? ArticleCategory { get; set; }
        private IArticleCategoryApplication _articleCategory { get; }

        public IndexModel(IArticleCategoryApplication articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public void OnGet()
        {
             ArticleCategory = _articleCategory.GetAll();
        }

        public IActionResult OnPostActive(string Id)
        {
            _articleCategory.Active(Id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnPostRemove(string Id)
        {
            _articleCategory.Delete(Id);
            return RedirectToPage("./Index");
        }
    }
}
