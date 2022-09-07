using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MasterIdentity.ClaimAndPolicyClass
{
    public  class AddClaim:IClaimsTransformation
    {
        private UserManager<IdentityUser> _userManager { get; }

        public AddClaim(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal? principal)
        {
            
            if (principal != null)
            {
                var id = principal.Identity as ClaimsIdentity;
                var user = await _userManager.FindByNameAsync(id?.Name);
                if (user != null)
                {
                    id.AddClaim(new Claim("EmailConfirmed", user.EmailConfirmed.ToString().ToLower()));
                    
                    
                }
                    
            }

            return principal!;
        }
    }
}
