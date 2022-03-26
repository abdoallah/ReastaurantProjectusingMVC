using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Core.Models
{
    public class MailVM
    {
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Message Required")]
        public string Message { get; set; }

        public string Email { get; set; }
    }
}
