using Microsoft.AspNetCore.Identity;

namespace MVC_Project.Core.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsAgree { get; set; }
        public string Address { get; set; }
        //public string Address { get; set; }


    }
}
