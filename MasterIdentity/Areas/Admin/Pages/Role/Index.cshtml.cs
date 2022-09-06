using MasterIdentity.Areas.Admin.Pages.Role.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MasterIdentity.Areas.Admin.Pages.Role
{
    public class IndexModel : PageModel
    {
        public List<RoleList> Rolelist { get; set; }
        private RoleManager<IdentityRole> _roleManager { get; }

        public IndexModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void OnGet()
        {
            Rolelist = _roleManager.Roles.Select(x => new RoleList
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async  Task<IActionResult>OnGetDelete(string id)
        {
            var findRole =await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(findRole);
            return RedirectToPage("/Index");
        }
    }
}
