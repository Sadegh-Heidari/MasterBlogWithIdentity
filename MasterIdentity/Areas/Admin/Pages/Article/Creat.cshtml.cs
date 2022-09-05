using ApplicationServices.Article;
using ApplicationServices.ArticleCategory;
using ApplicationServices.ArticleCategory.DTO;
using MasterIdentity.Areas.Admin.Pages.ViewModels;
using MasterIdentity.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterIdentity.Areas.Admin.Pages.Article
{
    public class CreatModel : PageModel
    {
        [BindProperty] public ArticleViewModel Article { get; set; }
        private IArticleCategoryApplication _ArticleCategoryApplication { get; }
        private IArticleApplication _ArticleApplication { get; }
        private IWebHostEnvironment _WebHostEnvironment { get; }

        public CreatModel(IArticleCategoryApplication articleCategory, IArticleApplication articleApplication, IWebHostEnvironment webHostEnvironment)
        {
            _ArticleCategoryApplication = articleCategory;
            _ArticleApplication = articleApplication;
            _WebHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            Article = new ArticleViewModel();
            Article.CategoryItem = _ArticleCategoryApplication.GetTitle().Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id
            }).ToList();
            if(Article.CategoryItem == null) return RedirectToPage("/ArticleCategory/Index");
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Article.ImageName = await ConvertImage.Excute(Article.UploadFile!, _WebHostEnvironment.WebRootPath);
                _ArticleApplication.AddArticle(Article.Title!, Article.ShortDescription!, Article.ImageName!, Article.Content!, Article.ArticleCategoryId!);
                return RedirectToPage("./Index");
            }
            Article.CategoryItem = _ArticleCategoryApplication.GetTitle().Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id
            }).ToList();
            return Page();
        }
    }
}
