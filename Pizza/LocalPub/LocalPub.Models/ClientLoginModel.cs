using System.ComponentModel.DataAnnotations;

namespace LocalPub.Models
{
    public class ClientLoginModel
    {
        [Required(ErrorMessage = "The username is required")]
        [MinLength(5, ErrorMessage = "The username must be at least {1} symbols long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [MinLength(6, ErrorMessage = "The password must be at least {1} symbols long")]
        public string Password { get; set; }
    }
}
