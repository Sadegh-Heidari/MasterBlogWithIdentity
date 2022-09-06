using MasterIdentity.Pages.Register.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MasterIdentity.Pages.Register
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty] public ResetPasswordViewModel ResetPassword { get; set; }
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }

        public ResetPasswordModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            ResetPassword = new ResetPasswordViewModel();
        }

        public IActionResult OnGet(string Id,string Token)
        {
            if(string.IsNullOrEmpty(Id)&& string.IsNullOrEmpty(Token)) return BadRequest();
            ResetPassword.Id = Id;
            ResetPassword.Token = Token;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(ResetPassword.Id);
                var result = await _userManager.ResetPasswordAsync(user, ResetPassword.Token, ResetPassword.Password);
                if (result.Succeeded)
                {
                    
                    TempData["ResetPassword"] = "Your Password Changed Successfully, Please Log In";
                    return Page();
                }
                if (!result.Succeeded)
                {
                    var er = String.Empty;
                    foreach (var error in result.Errors)
                    {
                        er += error.Description + Environment.NewLine;
                    }

                    TempData["Error"] = er;
                    return Page();
                }
            }

            return Page();
        }
    }
}
