using MasterIdentity.Areas.Admin.Pages.User.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterIdentity.Areas.Admin.Pages.User
{
    public class AddUserRoleModel : PageModel
    {
        [BindProperty] public AddUserRole addUserRole { get; set; }
        private UserManager<IdentityUser> _userManager { get;  }
        private RoleManager<IdentityRole> _roleManager { get; }
        public AddUserRoleModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void OnGet(string id)
        {
            addUserRole = new AddUserRole
            {
                Id = id,
                Roles = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Name
                }).ToList()
            };
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(addUserRole.Id);
                var result = await _userManager.AddToRoleAsync(user, addUserRole.Role);
                if (result.Succeeded)
                {
                    return RedirectToPage("./Index");
                }
            }

            return Page();
        }
    }
}
