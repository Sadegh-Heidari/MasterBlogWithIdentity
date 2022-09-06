using MasterIdentity.Pages.Register.ViewModel;
using MasterIdentity.Utility;
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
                    
                    var token =await _userManager.GenerateEmailConfirmationTokenAsync(NewUser);
                    var callbackURL = Url.PageLink("ConfirmEmail", null, new
                    {
                        Id = NewUser.Id,
                        Token = token
                    }, Request.Scheme);
                    string Body = "<h1>Please Accept your Email</h1>" +
                                  $"<br/><a href={callbackURL}>link</a>";
                    EmailSender.Execute(NewUser.Email, Body, "Accept Email");
                    TempData["ConfirmEmail"] = "Information has been successfully registered,Please Accept your Email and then Log In";
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
