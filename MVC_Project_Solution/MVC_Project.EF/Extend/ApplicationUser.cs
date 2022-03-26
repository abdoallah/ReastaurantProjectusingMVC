using Microsoft.AspNetCore.Identity;

namespace MVC_Project.EF.Extend
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAgree { get; set; }
    }
}
