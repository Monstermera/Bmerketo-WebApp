namespace WebApp.ViewModels.HomeView
{
    public class SaleViewModel
    {
        public string Ingress { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string SecondTitle { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Discover { get; set; } = null!;
        public IEnumerable<SaleItemViewModel> Sale { get; set; } = null!;


    }
}
