using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Core.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "This Field Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }



        [Required]
        [MinLength(6, ErrorMessage = "Min. length of Password is 6 characters")]
        public string Password { get; set; }


        public bool RememberMe { get; set; }

    }
}
