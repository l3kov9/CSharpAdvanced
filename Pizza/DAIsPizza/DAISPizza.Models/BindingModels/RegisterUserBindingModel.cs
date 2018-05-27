using System.ComponentModel.DataAnnotations;

namespace DAISPizza.Models.BindingModels
{
    public class RegisterUserBindingModel
    {
        [Required(ErrorMessage = "The username is required")]
        [MinLength(4, ErrorMessage = "The username should be at least {1} symbols long")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The password is required")]
        [MinLength(6, ErrorMessage = "The password should be at least {1} symbols long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The password confirmation is required")]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }
    }
}
