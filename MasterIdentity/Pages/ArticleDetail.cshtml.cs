using ApplicationServices.Comment;
using Infrastructure.Query.EFCORE;
using Infrastructure.Query.EFCORE.DTO;
using MasterIdentity.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages.Shared
{
    public class ArticleDetailModel : PageModel
    {
        [BindProperty] public CommentViewModel CommentViewModel { get; set; }
       [BindProperty] public ArticleQueryDTO Article { get; set; }
        private ICommentApplication commentApplication { get; }
        private IArticleList Comment { get; }

        public ArticleDetailModel(IArticleList comment, ICommentApplication commentApplication)
        {
            this.Comment = comment;
            this.commentApplication = commentApplication;
        }

        public void OnGet(string Id)
        {
            Article = Comment.GetArticle(id: Id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                commentApplication.AddComment(CommentViewModel.UserName!,CommentViewModel.Email!, CommentViewModel.Message!, CommentViewModel.ArticleId!);
                return RedirectToPage("/ArticleDetail", new { Id = Article.Id });
            }

            return Page();
        }
    }
}
