using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MasterIdentity.Areas.Admin.Pages.User.Dto
{
    public class AddUserRole
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Role { get; set; }
        public List<SelectListItem>? Roles { get; set; }
    }
}
