using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressAboutPage : ContentPage
    {
        public RadialProgressAboutPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundImage = "AppBackground.jpg";
            
            Content = new StackLayout
            {
                Padding = 5,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    // Add text here
                }
            };

        }
    }
}
