using MasterIdentity.Pages.Register.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Pages.Register
{
    public class SignUpModel : PageModel
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        [BindProperty] public SignUpViewModel SignUpViewModel { get; set; }
        public SignUpModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var userFind = await _userManager.FindByEmailAsync(SignUpViewModel.Email);
            if (userFind != null)
            {
                ModelState.AddModelError(String.Empty, "The user is Exist please Log in");
                return Page();
            }

            if (ModelState.IsValid)
            {
                var NewUser = new IdentityUser
                {
                    UserName = SignUpViewModel.Email,
                    Email = SignUpViewModel.Email
                };
                var result = await _userManager.CreateAsync(NewUser, SignUpViewModel.Password);
                
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(NewUser, true);
                    return RedirectToPage("/Index");
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
