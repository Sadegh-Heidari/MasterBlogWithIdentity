using MasterIdentity.Areas.Admin.Pages.Role.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.Role
{
    public class CreatRoleModel : PageModel
    {
        [BindProperty] public RoleList role { get; set; }
        private UserManager<IdentityUser> _userManager { get; }
        private RoleManager<IdentityRole> _roleManager { get;  }

        public CreatRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole
                {
                    Name = role.Name
                };
                var result = await _roleManager.CreateAsync(identityRole);
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

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
