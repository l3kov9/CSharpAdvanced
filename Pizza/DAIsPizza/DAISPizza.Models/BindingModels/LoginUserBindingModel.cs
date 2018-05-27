using System.ComponentModel.DataAnnotations;

namespace DAISPizza.Models.BindingModels
{
    public class LoginUserBindingModel
    {
        [Required(ErrorMessage = "The username is required")]
        [MinLength(4, ErrorMessage = "The username must be at least {1} symbols long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [MinLength(6, ErrorMessage = "The password should be at least {1} symbols long")]
        public string Password { get; set; }
    }
}