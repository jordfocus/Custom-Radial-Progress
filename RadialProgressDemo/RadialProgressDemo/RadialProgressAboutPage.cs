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
               new Label
                {
                    Text = "This is a demo project that demonstrates the cusom implementation of Xamarin.Fomrs Radial Progress control. You can read more on \nhttps://dotjord.wordpress.com/ \nor check the code on GitHub \nhttps://github.com/jordfocus/Custom-Radial-Progress",
                    Font = Font.SystemFontOfSize(NamedSize.Large),
                    HorizontalOptions = LayoutOptions.Center,
                }
                }
            };

        }
    }
}
