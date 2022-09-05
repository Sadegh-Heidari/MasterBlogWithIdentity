using MasterIdentity.Areas.Admin.Pages.User.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {
        public List<GetUserDto>? UserList { get; set; }
        private UserManager<IdentityUser> _userManager { get; }

        public IndexModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
             UserList = _userManager.Users.Select(x => new GetUserDto
            {
                AccessFieldCount = Convert.ToInt16(x.AccessFailedCount),
                EmailConfirmed = x.EmailConfirmed,
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                UserName = x.UserName,
                Email = x.Email
            }).ToList();
        }

        public async Task<IActionResult> OnGetDelete(string id)
        {
            var find = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(find);
            return RedirectToPage("./Index");
        }
    }
}
