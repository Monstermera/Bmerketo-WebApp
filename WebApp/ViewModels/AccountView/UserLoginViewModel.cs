using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels.AccountView
{
    public class UserLoginViewModel
    {

        [Required(ErrorMessage = "You must enter an email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail*")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; } = null!;


        [Display(Name = "Please keep me logged in")]
        public bool RememberMe { get; set; } = false;

    }
}
