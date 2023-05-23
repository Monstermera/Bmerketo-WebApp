using WebApp.ViewModels.HomeView;

namespace WebApp.Helpers.Services.Home
{
    public class ReviewService
    {
        private ReviewViewModel review = new ReviewViewModel()
        {
            GridItems = new List<ReviewItemViewModel>
                {
                    new ReviewItemViewModel
                    {
                        Title = "Table lamp 1562 LTG modal",
                        Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno",
                        Admin = "POST BY: ADMIN",
                        Comment = "COMMENTS 13",
                        ImageUrl = "images/placeholders/lamp1.png"
                    },
                    new ReviewItemViewModel
                    {
                        Title = "Table lamp 1562 LTG modal",
                        Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno",
                        Admin = "POST BY: ADMIN",
                        Comment = "COMMENTS 13",
                        ImageUrl = "images/placeholders/lamp2.png"
                    },
                    new ReviewItemViewModel
                    {
                        Title = "Table lamp 1562 LTG modal",
                        Description = "Best dress for everyone ed totam velit risus viverra nobis donec recusandae perspiciatis incididuno",
                        Admin = "POST BY: ADMIN",
                        Comment = "COMMENTS 13",
                        ImageUrl = "images/placeholders/lamp3.png"
                    },
                }
        };

        public ReviewViewModel GetReview()
        {
            return review;
        }
    }
}
