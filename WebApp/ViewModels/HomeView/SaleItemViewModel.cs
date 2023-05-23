namespace WebApp.ViewModels.HomeView
{
    public class SaleItemViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string CardTitle { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }


    }
}
