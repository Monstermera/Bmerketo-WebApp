using WebApp.ViewModels.HomeView;

namespace WebApp.Helpers.Services.Home
{
    public class SaleService
    {
        private SaleViewModel sale = new SaleViewModel()
        {
            Ingress = "UP T SELL",
            Title = "50% OFF",
            SecondTitle = "Get The Best Price",
            Description = "Get the best daily offer et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren no sea taki",
            Discover = "Discover More",

            Sale = new List<SaleItemViewModel>
                {
                    new SaleItemViewModel { Id = "1", CardTitle = "Table lamp - scelerisque tempore", OldPrice = 50, Price = 30, ImageUrl = "images/placeholders/girls.png" },
                    new SaleItemViewModel { Id = "2", CardTitle = "Table lamp - scelerisque tempore", OldPrice = 50, Price = 30, ImageUrl = "images/placeholders/2girls.png" }
                }
        };

        public SaleViewModel GetSale()
        {
            return sale;
        }
    }
}
