using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities.User;
using WebApp.Models.Identity;

namespace WebApp.ViewModels.AccountView
{
    public class UserRegisterViewModel
    { 
        [Required(ErrorMessage = "You must enter a first name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Please enter a valid first name")]
        [Display(Name = "First Name*")]
        public string FirstName { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a last name")]
        [RegularExpression(@"^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$", ErrorMessage = "Please enter a valid last name")]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a street name")]
        [Display(Name = "Street Name*")]
        public string StreetName { get; set; } = null!;


        [Required(ErrorMessage = "You must enter postal code")]
        [Display(Name = "Postal Code*")]
        public string PostalCode { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a city")]
        [Display(Name = "City*")]
        public string City { get; set; } = null!;


        [Display(Name = "Mobile (optional)")]
        public string? PhoneNumber { get; set; }


        [Display(Name = "Company (optional)")]
        public string? Company { get; set; }


        [Required(ErrorMessage = "You must enter a e-mail address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid e-mail address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail*")]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "You must enter a password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "The password must contain at least eight characters, including an uppercase and lowercase letter, one number and special characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = "You must confirm the password")]
        [Compare(nameof(Password), ErrorMessage = "The password doesn't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password*")]
        public string ConfirmPassword { get; set; } = null!;


        [Display(Name = "Upload Profile Image (optional)")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }


        [Required(ErrorMessage = "You must agree to the terms and agreements")]
        [Display(Name = "I have read and accepts the terms and agreements")]
        public bool Terms { get; set; } = false;



        #region implicit operators
        public static implicit operator AppUser(UserRegisterViewModel model)
        {
            return new AppUser
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Company = model.Company,
            };
        }

        public static implicit operator AddressEntity(UserRegisterViewModel model)
        {
            return new AddressEntity
            {
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                City = model.City,

            };
        }

        #endregion

    }
}
