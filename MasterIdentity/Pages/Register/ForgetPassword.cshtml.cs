using MasterIdentity.Pages.Register.ViewModel;
using MasterIdentity.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages.Register
{
    public class ForgetPasswordModel : PageModel
    {
        [BindProperty] public ForGetPasswordViewModel forget { get; set; }
        private UserManager<IdentityUser> _userManager { get; }

        public ForgetPasswordModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(forget.Email);
                if (user == null)
                {
                    TempData["UserExist"] = "Your information has not been registered.Please Sign Up";
                    return Page();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user!);
                var callbackURL = Url.PageLink("ResetPassword", null, new
                {
                    Id = user.Id,
                    Token = token
                }, Request.Scheme);
                string Body = "<h1>Please Reset your Password</h1>" +
                              $"<br/><a href={callbackURL}>link</a>";
                EmailSender.Execute(user.Email, Body, "Accept Email");
                TempData["ConfirmPassword"] = "Please Check your Email and then Reset your Password";
                return Page();

            }

            return Page();
        }
    }
}
