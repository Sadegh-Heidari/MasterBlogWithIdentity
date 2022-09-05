using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.DTO;
using MasterIdentity.Areas.Admin.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.ArticleCategory
{
    public class AddNewModel : PageModel
    {
       [BindProperty] public ArticleCategoryViewModel ArticleCategory { get; set; }
        private IArticleCategoryApplication _articleCategoryModel { get; }

        public AddNewModel(IArticleCategoryApplication articleCategoryModel)
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
                _articleCategoryModel.Add(ArticleCategory.Title!);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
