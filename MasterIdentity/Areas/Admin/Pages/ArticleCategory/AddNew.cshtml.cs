using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.ArticleCategory
{
    public class AddNewModel : PageModel
    {
       [BindProperty] public ArticleCategoryGetAndAddViewModel? ArticleCategory { get; set; }
        private IArticleCategoryApplicationServices _articleCategoryModel { get; }

        public AddNewModel(IArticleCategoryApplicationServices articleCategoryModel)
        {
            _articleCategoryModel = articleCategoryModel;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _articleCategoryModel.Add(ArticleCategory!);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
