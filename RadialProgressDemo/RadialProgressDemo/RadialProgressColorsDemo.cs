using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadialProgressDemo
{
    public class RadialProgressColorsDemo : ContentPage
    {
        private Slider redSlider;
        private Slider greenSlider;
        private Slider blueSlider;
        private Slider alfaSlider;
        private Picker elementColorPicker;
        private RadialProgress radialProgress;
        public RadialProgressColorsDemo()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Title = "Radial progress COLOR demo";
            var headerInfoLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Orientation = StackOrientation.Horizontal,
                Children = 
                        {
                            new Label 
                            {
							    Text = "Radial progress COLOR demo",
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
                Maximum = 250,
                Value = 128
            };
            #region Init Elements
            radialProgress = new RadialProgress
            {
                Diameter = 200,
                DisplayMode = DisplayModeTypes.ShowProgress,
                Max = 250,
                Progress = 128,
                FillColor = new Color(0, 255, 0, 0.3)
            };
            elementColorPicker = new Picker
            {
                Title = "Select element",
                Items = { "Border color", "Fill color", "Text color", "Max Border color" },
                SelectedIndex = 0
            };

            redSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
               
            };
            greenSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100
            };
            blueSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100
            };
            alfaSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100
            };
            SetColorSliders();
            #endregion
            #region EventHandlers
            redSlider.ValueChanged += async (sender, e) =>
            {
                UpdateProgressElementColorColor(
                    e.NewValue / 100
                    , greenSlider.Value / 100
                    , blueSlider.Value / 100
                    , alfaSlider.Value/100);
            };
            greenSlider.ValueChanged += async (sender, e) =>
            {
                UpdateProgressElementColorColor(
                    redSlider.Value / 100
                    , e.NewValue / 100
                    , blueSlider.Value / 100
                    , alfaSlider.Value / 100);
            };
            blueSlider.ValueChanged += async (sender, e) =>
            {
                UpdateProgressElementColorColor(
                    redSlider.Value / 100
                    , greenSlider.Value / 100
                    , e.NewValue / 100
                    , alfaSlider.Value / 100);
            };
            alfaSlider.ValueChanged += async (sender, e) =>
            {
                UpdateProgressElementColorColor(
                    redSlider.Value / 100
                    , greenSlider.Value / 100
                    , blueSlider.Value / 100
                    , e.NewValue / 100);
            };
            slider.ValueChanged += async (sender, e) =>
            {
                radialProgress.Progress = (int)e.NewValue;
            };
            elementColorPicker.SelectedIndexChanged += async (sender, e) =>
            {
                SetColorSliders();
            };
            #endregion
            var contentLayout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = 
                {
                    slider,
                    radialProgress,
                    elementColorPicker,
                    new Label 
                    {
						Text = "RED",
                        FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
                        TextColor = Color.Red
					},
                    redSlider,
                    new Label 
                    {
						Text = "GREEN",
                        FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
                        TextColor = Color.Green
					},
                    greenSlider,
                    new Label 
                    {
						Text = "BLUE",
                        FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
                        TextColor = Color.Blue
					},
                    blueSlider,
                    new Label 
                    {
						Text = "ALFA",
                        FontSize = Device.GetNamedSize (NamedSize.Small, typeof(Label)),
                        TextColor = Color.White
					},
                    alfaSlider
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

        private void SetColorSliders()
        {
            var color = Color.White;
            switch (elementColorPicker.SelectedIndex)
            {
                case 0:
                    color = radialProgress.BorderColor;
                    break;
                case 1:
                    color = radialProgress.FillColor;
                    break;
                case 2:
                    color = radialProgress.TextColor;
                    break;
                case 3:
                    color = radialProgress.MaxReachedBorderColor;
                    break;
            }

            redSlider.Value = color.R*100;
            greenSlider.Value = color.G*100;
            blueSlider.Value = color.B*100;
            alfaSlider.Value = color.A*100;
        }

        private void UpdateProgressElementColorColor(double red, double green, double blue, double alfa)
        {
            var color = new Color(
                   red
                   , green
                   , blue
                   , alfa);
            switch (elementColorPicker.SelectedIndex)
            {
                case 0:
                    radialProgress.BorderColor = color;
                    break;
                case 1:
                    radialProgress.FillColor = color;
                    break;
                case 2:
                    radialProgress.TextColor = color;
                    break;
                case 3:
                    radialProgress.MaxReachedBorderColor = color;
                    break;
            }
        }
    }
}
