using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        [BindProperty] public ArticleCategoryGetAndAddViewModel? art { get; set; }
        private IArticleCategoryApplicationServices _articleCategory { get; }

        public EditModel(IArticleCategoryApplicationServices articleCategory)
        {
            _articleCategory = articleCategory;
        }

        public IActionResult OnGet()
        {
            if (String.IsNullOrEmpty(art?.Id)) return  BadRequest();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (String.IsNullOrEmpty(art?.Id)) return BadRequest();
            return Page();
        }

        public IActionResult OnPostResponse()
        {
            if (ModelState.IsValid)
            {
                _articleCategory.Update(art!);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
