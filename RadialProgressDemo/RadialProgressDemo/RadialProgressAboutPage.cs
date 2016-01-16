using System;
using Microsoft.VisualBasic;
using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressAboutPage : ContentPage
    {
        public RadialProgressAboutPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundImage = "AppBackground.jpg";

            var blogURILabel = new Label()
            {
                Text = "https://dotjord.wordpress.com",
                TextColor = Color.Blue,
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };
            
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += async (s, e) =>
            {
                try
                {
                    Device.OpenUri(new Uri("https://dotjord.wordpress.com"));
                }
                catch (Exception ex)
                {
                    //
                }
            };
            blogURILabel.GestureRecognizers.Add(tgr);

            var gitHubURILabel = new Label()
            {
                Text = "https://github.com/jordfocus/",
                TextColor = Color.Blue,
                FontSize = 22,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start
            };

            var tgrGitHub = new TapGestureRecognizer();
            tgrGitHub.Tapped += async (s, e) =>
            {
                try
                {
                    Device.OpenUri(new Uri("https://github.com/jordfocus/Custom-Radial-Progress"));
                }
                catch (Exception ex)
                {
                    //
                }
            };
            gitHubURILabel.GestureRecognizers.Add(tgrGitHub);

            Content = new StackLayout
            {
                Padding = 5,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                new Label
                {
                    Text = "This is a demo project that demonstrates the cusom implementation of Xamarin.Fomrs Radial Progress control. You can read more on \n",
                    Font = Font.SystemFontOfSize(NamedSize.Large),
                    HorizontalOptions = LayoutOptions.Center,
                },
                blogURILabel,
                new Label
                {
                    Text = "\nor check the code on GitHub \n",
                    Font = Font.SystemFontOfSize(NamedSize.Large),
                    HorizontalOptions = LayoutOptions.Center,
                },
                gitHubURILabel
                }
            };

        }
    }
}
