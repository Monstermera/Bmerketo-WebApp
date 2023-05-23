using WebApp.ViewModels.HomeView;

namespace WebApp.ViewModels
{
	public class HomeIndexViewModel
	{
		public ShowcaseViewModel Showcase { get; set; } = null!;
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public SaleViewModel Sale { get; set; } = null!;
        public TopSellingViewModel TopSelling { get; set; } = null!;
        public ReviewViewModel Review { get; set; } = null!;

    }
}
