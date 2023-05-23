namespace WebApp.ViewModels.HomeView
{
    public class TopSellingViewModel
    {
        public string? Title { get; set; } = "";
        public IEnumerable<GridCollectionItemViewModel> GridItems { get; set; } = null!;
        public bool Angle { get; set; } = false;
    }
}
