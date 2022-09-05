using ApplicationServices.Comment;
using ApplicationServices.Comment.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.Comments
{
    public class IndexModel : PageModel
    {
        public List<CommentListDTO> ListComments { get; set; }
        private ICommentApplication _comment { get; }

        public IndexModel(ICommentApplication comment)
        {
            _comment = comment;
        }

        public void OnGet()
        {
            ListComments = _comment.GetAllComments();
        }

        public IActionResult OnPostConfirm(string Id)
        {
            if (Id == null) return new BadRequestResult();
            _comment.Confirm(Id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostCancel(string Id)
        {
            if (Id == null) return new BadRequestResult();
            _comment.Cancel(Id);
            return RedirectToPage("./Index");
        }
    }
}
