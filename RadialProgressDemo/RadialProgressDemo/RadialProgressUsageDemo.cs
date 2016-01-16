using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressUsageDemo : ContentPage
    {
        public RadialProgressUsageDemo()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Radial progress demo";
            var headerInfoLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = 
                        {
                            new Label 
                            {
							    Text = "Radial progress demo",
                                FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label))
						    }
                        }
            };
            var headerLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                Children = 
                {
                   headerInfoLayout
                }
            };
            var slider = new Slider
            {
                Minimum = 0,
                Maximum = 250
            };

            var radialProgress = new RadialProgress
            {
                Diameter = 200,
                DisplayMode = DisplayModeTypes.ShowPercentage,
                Max = 250,
                FillColor = new Color(0, 255, 0, 0.3)
            };

            var radialProgressTwo = new RadialProgress
            {
                Diameter = 200,
                DisplayMode = DisplayModeTypes.ShowPercentage,
                Max = 250
            };
            slider.ValueChanged += async (sender, e) =>
            {
                radialProgress.Progress = (int)e.NewValue;
                radialProgressTwo.Progress = (int)e.NewValue;
            };
            var btnProgress = new Button
            {
                Text = "+10",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };
            btnProgress.Clicked += async (sender, e) =>
            {
                radialProgress.Progress += 10;
            };
            var btnDecrease = new Button
            {
                Text = "-10",
                TextColor = Color.White,
                BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            btnDecrease.Clicked += async (sender, e) =>
            {
                radialProgress.Progress -= 10;
            };
            var increaseDecreaseLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = 0,
                Children =
                {
                    btnProgress,
                    btnDecrease
                }
            };
            var btnSwitchMode = new Button
            {
                Text = "Switch Display Mode",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            btnSwitchMode.Clicked += async (sender, e) =>
            {
                if (radialProgress.DisplayMode == DisplayModeTypes.ShowProgress)
                {
                    radialProgress.DisplayMode = DisplayModeTypes.ShowPercentage;
                    radialProgress.ProgressText = "Percentage Mode";
                }
                else
                {
                    radialProgress.DisplayMode = DisplayModeTypes.ShowProgress;
                    radialProgress.ProgressText = "Progress Mode";
                }
            };
            var btnReset = new Button
            {
                Text = "Reset",
                TextColor = Color.White,
                BackgroundColor = Color.Green
            };
            btnReset.Clicked += async (sender, e) =>
            {
                radialProgress.Progress = 0;
                radialProgress.ProgressText = string.Empty;
            };
            var butonsLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children =
                {
                    increaseDecreaseLayout,
                    btnSwitchMode,
                    btnReset
                }
            };
            var contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = 
                {
                    slider,
                    radialProgress,
                    butonsLayout
                }
            };
            var footerLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.End,
                Children = 
                {
                    //radialProgress,
                    new Label 
                    {
							Text = "Made by Jordan Atanasovski 1.0"
					}
                }
            };
            BackgroundImage = "AppBackground.jpg";
            // The root page of your application

            Content = new StackLayout
            {
                // this must be fill and expand in order for this to work
                // VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    // headerLayout,
                    contentLayout,
                    footerLayout
                }
            };

        }
    }
}
