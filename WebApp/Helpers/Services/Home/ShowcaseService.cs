using WebApp.ViewModels.HomeView;

namespace WebApp.Helpers.Services.Home
{
    public class ShowcaseService
    {
        private ShowcaseViewModel showcase = new ShowcaseViewModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair gold Collection",
            LinkContent = "SHOP NOW",
            LinkUrl = "/products",
            ImageUrl = "images/placeholders/gold-chair.png"
        };

        public ShowcaseViewModel GetShowCase()
        {
            return showcase;
        }
    }
}

