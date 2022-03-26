using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Core.Models
{
    public class ForgetPasswordVM
    {
        [Required(ErrorMessage = "This Field Required")]
        [EmailAddress(ErrorMessage = "Invalid Mail Address")]
        public string Email { get; set; }
    }
}
