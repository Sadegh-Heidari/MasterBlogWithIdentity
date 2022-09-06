using System.ComponentModel.DataAnnotations;

namespace MasterIdentity.Areas.Admin.Pages.Role.ViewModel
{
    public class RoleList
    {
        public string? Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
