using MasterIdentity.Areas.Admin.Pages.User.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.User
{
    public class UserRolesModel : PageModel
    {
        public UsersRole usersRole { get; set; }
        private UserManager<IdentityUser> _userManager { get; }

        public UserRolesModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task OnGet(string id)
        {
            usersRole = new UsersRole();
            var user = await _userManager.FindByIdAsync(id);
            usersRole.RoleUsers = await _userManager.GetRolesAsync(user);
        }
    }
}
