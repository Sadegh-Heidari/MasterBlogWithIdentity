using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.DTO;
using MasterIdentity.Areas.Admin.Pages.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.ArticleCategory
{
    public class EditModel : PageModel
    {
        [BindProperty] public ArticleCategoryViewModel art { get; set; }
        private IArticleCategoryApplication _articleCategory { get; }

        public EditModel(IArticleCategoryApplication articleCategory)
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
                _articleCategory.Update(art.Title!,art.Id!);
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
