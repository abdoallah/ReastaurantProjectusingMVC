using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Core.Models
{
    public class ResetPasswordVM
    {

        [Required]
        [MinLength(6, ErrorMessage = "Min. length of Password is 6 characters")]
        public string Password { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Min. length of Password is 6 characters")]
        [Compare("Password", ErrorMessage = "Password not Matched")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }



    }
}
