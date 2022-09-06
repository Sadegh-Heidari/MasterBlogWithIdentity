using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages.Register
{
    public class ConfirmEmailModel : PageModel
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }

        public ConfirmEmailModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> OnGet(string Id,string Token)
        {
            if (Id == null && Token == null)
            {
                return BadRequest(); 
            }

            var user = await _userManager.FindByIdAsync(Id);
            var result = await _userManager.ConfirmEmailAsync(user, Token);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
