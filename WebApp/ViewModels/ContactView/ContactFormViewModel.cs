using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels.ContactView
{
    public class ContactFormViewModel
    {

        [Required(ErrorMessage = "You must enter your name")]
        [Display(Name = "Your Name*")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "You must enter an email")]
        [Display(Name = "Your Email*")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "You must enter a phone number")]
        [Display(Name = "Phone Number*")]
        public string PhoneNumber { get; set; } = null!;

        [Display(Name = "Company (optional)")]
        public string? Company { get; set; }

        [Required(ErrorMessage = "Please describe how we can help you")]
        [Display(Name = "Something write*")]
        public string Message { get; set; } = null!;


        [Display(Name = "Save my name, email and website in this browser for the next time I comment.")]
        public bool SaveInfo { get; set; } = false;

        #region implicit operator 
        public static implicit operator ContactEntity(ContactFormViewModel model)
        {
            return new ContactEntity
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Company = model.Company,
                Message = model.Message,
            };

        }

    
        #endregion
    }
}
