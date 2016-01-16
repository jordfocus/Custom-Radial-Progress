
using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressFootballStatsDemo : ContentPage
    {
        private RadialProgress radialProgressStats1;
        private RadialProgress radialProgressStats2;
        private RadialProgress radialProgressStats3;
        private RadialProgress radialProgressStats4;
        Label topLeftLabel, centerLabel, bottomRightLabel;
        public RadialProgressFootballStatsDemo()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Title = " Radial progress stats demo "; 
            var borderColor = new Color((double)216/ 255, (double)26 / 255, (double)36 / 255, 0.7);
            var fillColor = new Color((double)6 / 255, (double)27 / 255, (double)142 / 255, 0.5);
            var textColor = new Color((double)255 / 255, (double)255 / 255, (double)38 / 255, 1);
            
            var headerInfo = new Label
            {
                Text = ">> TAP controls to increase values",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                HorizontalOptions = LayoutOptions.Center,
                TextColor = textColor,
                BackgroundColor = borderColor
            };

            radialProgressStats1 = new RadialProgress
            {
                Progress = 81,  
                Diameter = 100,
                BorderColor = borderColor,
                FillColor = fillColor,
                TextColor = textColor,
                ProgressText = "Pass Accuracy",
                DisplayMode = DisplayModeTypes.ShowPercentage
            };
            radialProgressStats2 = new RadialProgress
            {
                Progress = 17,
                Max = 17,
                Diameter = 150,
                BorderColor = borderColor,
                MaxReachedBorderColor = borderColor,
                FillColor = fillColor,
                TextColor = textColor,
                ProgressText = "Goals",
                DisplayMode = DisplayModeTypes.ShowProgress
            };
            radialProgressStats3 = new RadialProgress
            {
                Progress = 65,
                Diameter = 100,
                BorderColor = borderColor,
                FillColor = fillColor,
                TextColor = textColor,
                ProgressText = "Duels Won",
                DisplayMode = DisplayModeTypes.ShowPercentage
            };
            radialProgressStats4 = new RadialProgress
            {
                Progress = 61,
                Diameter = 100,
                BorderColor = borderColor,
                FillColor = fillColor,
                TextColor = textColor,
                ProgressText = "Shots Accuracy",
                DisplayMode = DisplayModeTypes.ShowPercentage
            };
            var simpleLayout = new AbsoluteLayout
            {
                //BackgroundColor = Color.Blue.WithLuminosity(0.9),
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var btnReset = new Button
            {
                Text = "Reset",
                TextColor = textColor,
                BackgroundColor = borderColor
            };

            AbsoluteLayout.SetLayoutFlags(radialProgressStats1,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(radialProgressStats1,
                new Rectangle(0.6,
                    0.1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(radialProgressStats2,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(radialProgressStats2,
                new Rectangle(1f,
                    0.3, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(radialProgressStats3,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(radialProgressStats3,
                new Rectangle(1f,
                    0.6, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(radialProgressStats4,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(radialProgressStats4,
                new Rectangle(1f,
                    0.85, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(btnReset,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(btnReset,
                new Rectangle(0.5f,
                    1, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            AbsoluteLayout.SetLayoutFlags(headerInfo,
                AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(headerInfo,
                new Rectangle(0.1f,
                    0.0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            var progressOneTapGesture = new TapGestureRecognizer();
            progressOneTapGesture.Tapped += async (s, e) =>
            {
                radialProgressStats1.Progress++;
            };
            radialProgressStats1.GestureRecognizers.Add(progressOneTapGesture);

            var progressTwoTapGesture = new TapGestureRecognizer();
            progressTwoTapGesture.Tapped += async (s, e) =>
            {
                radialProgressStats2.Progress++;
            };
            radialProgressStats2.GestureRecognizers.Add(progressTwoTapGesture);

            var progressThreeTapGesture = new TapGestureRecognizer();
            progressThreeTapGesture.Tapped += async (s, e) =>
            {
                radialProgressStats3.Progress++;
            };
            radialProgressStats3.GestureRecognizers.Add(progressThreeTapGesture);

            var progressFourTapGesture = new TapGestureRecognizer();
            progressFourTapGesture.Tapped += async (s, e) =>
            {
                radialProgressStats4.Progress++;
            };
            radialProgressStats4.GestureRecognizers.Add(progressFourTapGesture);

            btnReset.Clicked += (sender, args) =>
            {
                radialProgressStats1.Progress = 0;
                radialProgressStats2.Progress = 0;
                radialProgressStats3.Progress = 0;
                radialProgressStats4.Progress = 0;
            };

            simpleLayout.Children.Add(headerInfo);
            simpleLayout.Children.Add(radialProgressStats1);
            simpleLayout.Children.Add(radialProgressStats2);
            simpleLayout.Children.Add(radialProgressStats3);
            simpleLayout.Children.Add(radialProgressStats4);
            simpleLayout.Children.Add(btnReset);

            // Accomodate iPhone status bar.
            this.Padding =
                new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            var headerInfoLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = 
                        {
                            new Label 
                            {
							    Text = "Radial progress stats demo",
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
        
            var contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = 
                {
                    
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
            BackgroundImage = "Messi.jpg";
            // The root page of your application

            Content = new StackLayout
            {
                // this must be fill and expand in order for this to work
                // VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    // headerLayout,
                    simpleLayout,
                    footerLayout
                }
            };

        }
    }
}
