using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Core.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "This Field Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }



        [Required]
        [MinLength(6, ErrorMessage = "Min. length of Password is 6 characters")]
        public string Password { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Min. length of Password is 6 characters")]
        [Compare("Password", ErrorMessage = "Password not Matched")]
        public string ConfirmPassword { get; set; }


        public bool IsAgree { get; set; }
    }
}
