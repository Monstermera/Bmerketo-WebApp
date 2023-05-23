namespace WebApp.ViewModels.AdminView
{
    public class UserInformationViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!; 
        public string Email { get; set; } = null!;
        public string? Company { get; set; }
        public string? ProfileImage { get; set; }
        public string Role { get; set; } = null!;

        public ICollection<AddressViewModel> Addresses { get; set; } = new List<AddressViewModel>();

    }
}
