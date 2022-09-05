using Application.ArticleCategory;
using ApplicationServices.Article;
using ApplicationServices.ArticleCategory;
using MasterIdentity.Areas.Admin.Pages.ViewModels;
using MasterIdentity.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterIdentity.Areas.Admin.Pages.Article
{
    public class EditModel : PageModel
    {
        [BindProperty] public ArticleViewModel Article { get; set; }
        private IArticleApplication _articleApplication { get; }
        private IArticleCategoryApplication _articleCategory { get; }
        private IWebHostEnvironment _webHostEnvironment { get; }

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategory, IWebHostEnvironment webHostEnvironment)
        {
            _articleApplication = articleApplication;
            _articleCategory = articleCategory;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet(string? id)
        {
            if (String.IsNullOrWhiteSpace(id)) return new BadRequestResult();
            var article = _articleApplication.getArticle(id!);
            Article = new ArticleViewModel();
            Article.Id = id;
            Article.Content = article.Content;
            Article.ImageName = article.Image;
            Article.Title = article.Title;
            Article.ShortDescription = article.ShortDescription;
            Article.CategoryItem = _articleCategory.GetTitle().Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id
            }).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostConfirm()
        {
            if (ModelState.IsValid)
            {
                Article.ImageName = await ConvertImage.Excute(Article.UploadFile!, _webHostEnvironment.WebRootPath);
                _articleApplication.EditArticle(Article.Id!, Article.Title!, Article.ShortDescription!,
                    Article.ImageName, Article.Content!, Article.ArticleCategoryId!);
                return RedirectToPage("./Index");
            }
            Article.CategoryItem = _articleCategory.GetTitle().Select(x => new SelectListItem
            {
                Text = x.Title,
                Value = x.Id
            }).ToList();
            return Page();
        }
    }
}
