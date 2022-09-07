using ApplicationServices.Comment;
using Infrastructure.Query.EFCORE;
using Infrastructure.Query.EFCORE.DTO;
using MasterIdentity.Pages.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private IAuthorizationService authorizationService { get; }
        private UserManager<IdentityUser> userManager { get; }
        private SignInManager<IdentityUser> signInManager { get; }
        public ArticleDetailModel(IArticleList comment, ICommentApplication commentApplication, IAuthorizationService authorizationService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.Comment = comment;
            this.commentApplication = commentApplication;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        
        public async Task OnGet(string Id)
        {
            CommentViewModel = new CommentViewModel();
            Article = Comment.GetArticle(id: Id);
            var user = await userManager.GetUserAsync(User);
            if (user == null) CommentViewModel.Email = "Email Address (will not be published)";
            else
            {
                CommentViewModel.Email = user.Email;
            }

        }
        
        public async Task<IActionResult> OnPost()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                await signInManager.SignOutAsync();
                TempData["UserNull"] = "Please Sing up or login";
                Article = Comment.GetArticle(id: Article.Id!);
                return Page();
            }
            if (ModelState.IsValid)
            {
                
                commentApplication.AddComment(CommentViewModel.UserName!,CommentViewModel.Email!, CommentViewModel.Message!, CommentViewModel.ArticleId!);
                return RedirectToPage("/ArticleDetail", new { Id = Article.Id });
            }
            Article = Comment.GetArticle(id: Article.Id!);
            return Page();
        }
    }
}
