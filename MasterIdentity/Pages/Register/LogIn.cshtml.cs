using MasterIdentity.Pages.Register.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages.Register
{
    public class LogInModel : PageModel
    {
        [BindProperty] public LogInViewModel login { get; set; }
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }

        public LogInModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                
                var UserFind = await _userManager.FindByEmailAsync(login.Email);

                if (UserFind == null)
                {
                    ModelState.AddModelError(String.Empty,"The User is not exist. Please Sing Up");
                    return Page();
                }

                if (UserFind.EmailConfirmed == false)
                {
                    ModelState.AddModelError(String.Empty, "Please Confirm Your Email");
                    return Page();

                }
                var result =
                    await _signInManager.PasswordSignInAsync(UserFind, login.Password, login.IsPersistance, false);
                
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                
                if(!result.Succeeded)
                {
                    
                    ModelState.AddModelError("","Your Password is not correct");
                    return Page();
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnGetLogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
