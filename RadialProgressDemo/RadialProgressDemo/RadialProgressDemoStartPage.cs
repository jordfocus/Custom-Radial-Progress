
using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressDemoStartPage: ContentPage
    {
        public RadialProgressDemoStartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundImage = "AppBackground.jpg";
            var btnColorsDemo = new Button
            {
                Text = "Color Demo",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            var btnUsageDemo = new Button
            {
                Text = "Usage Demo",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            var btnPlayerStatsDemo = new Button
            {
                Text = "Player Stats Demo",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            var btnAbout = new Button
            {
                Text = "About",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };

            btnColorsDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new RadialProgressColorsDemo());
            };
            btnUsageDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new RadialProgressUsageDemo());
            };
            btnPlayerStatsDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new RadialProgressFootballStatsDemo());
            };
            Content = new StackLayout
            {
                // this must be fill and expand in order for this to work
                // VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = 5,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    btnColorsDemo,
                    btnUsageDemo,
                    btnPlayerStatsDemo,
                    btnAbout
               }
            };

        }
    }
}
