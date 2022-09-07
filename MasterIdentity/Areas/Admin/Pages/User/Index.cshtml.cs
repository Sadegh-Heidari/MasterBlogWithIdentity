using System.Net;
using System.Security.Claims;
using MasterIdentity.Areas.Admin.Pages.User.Dto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.HttpSys;

namespace MasterIdentity.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {
        
        public List<GetUserDto>? UserList { get; set; }
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signInManager { get; }
        public IndexModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
