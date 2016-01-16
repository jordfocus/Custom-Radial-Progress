using Xamarin.Forms;

namespace RadialProgressDemo
{
    /// <summary>
    /// Radial progress display types
    /// </summary>
    public enum DisplayModeTypes
    {
        None = 0 ,
        ShowPercentage = 1,
        ShowProgress = 2
    }
    /// <summary>
    /// Xamarin.Forms custom control. Contains bindable properties needed for the custom platform 
    /// renderer implementetions
    /// </summary>
    public class RadialProgress : View
    {
#region BindableProperties
        public static readonly BindableProperty ProgressProperty =
                BindableProperty.Create<RadialProgress, int>(p => p.Progress, 0);

        public static readonly BindableProperty BorderColorProperty =
                BindableProperty.Create<RadialProgress, Color>(p => p.BorderColor, Color.Blue);

        public static readonly BindableProperty FillColorProperty =
                BindableProperty.Create<RadialProgress, Color>(p => p.FillColor, Color.Green);

        public static readonly BindableProperty TextColorProperty =
                BindableProperty.Create<RadialProgress, Color>(p => p.TextColor, Color.White);

        public static readonly BindableProperty MaxReachedColorProperty =
                BindableProperty.Create<RadialProgress, Color>(p => p.MaxReachedBorderColor, Color.Red);

        public static readonly BindableProperty DisplayModeProperty =
                BindableProperty.Create<RadialProgress, DisplayModeTypes>(p => p.DisplayMode, DisplayModeTypes.ShowProgress);

        public static readonly BindableProperty ProgressTextProperty =
                BindableProperty.Create<RadialProgress, string>(p => p.ProgressText, string.Empty);
#endregion
#region Properties
        /// <summary>
        /// Value of the progress of the control that can be between Min and Max.
        /// Changeable in runtime.
        /// </summary>
        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set
            {
                if (value < 0)
                {
                    SetValue(ProgressProperty, 0);   
                }
                else if (value > Max)
                {
                    SetValue(ProgressProperty, Max);
                }
                else
                {
                    SetValue(ProgressProperty, value);
                }
            }
        }
        /// <summary>
        /// Determimnes the border color of the radial progress
        /// Changeable in runtime.
        /// </summary>
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
        /// <summary>
        /// Determimnes the fill color of the radial progress
        /// Changeable in runtime.
        /// </summary>
        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }
        /// <summary>
        /// Determimnes the border color when the maximum progress is reached.
        /// Changeable in runtime.
        /// </summary>
        public Color MaxReachedBorderColor
        {
            get { return (Color)GetValue(MaxReachedColorProperty); }
            set { SetValue(MaxReachedColorProperty, value); }
        }
        /// <summary>
        /// Determimnes the text color.
        /// Changeable in runtime.
        /// </summary>
        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
        /// <summary>
        /// The diameter is the value of HeightRequest and WidthRequest
        /// Changeable in runtime.
        /// </summary>
        public double Diameter
        {
            get { return WidthRequest; }
            set
            {
                WidthRequest = value;
                HeightRequest = value;
            }
        }

        private int _min = 0;
        /// <summary>
        /// The minimum value that the Progress can reach
        /// </summary>
        public int Min
        {
            get { return _min; }
        }

        private int _max = 100;
        /// <summary>
        /// The maximum value that the Progress can reach
        /// </summary>
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }
        /// <summary>
        /// Sets display mode Property or Percentage
        /// </summary>
        public DisplayModeTypes DisplayMode
        {
            get { return (DisplayModeTypes)GetValue(DisplayModeProperty); }
            set { SetValue(DisplayModeProperty, value); }
        }
        /// <summary>
        /// The progress text if we want any
        /// </summary>
        public string ProgressText
        {
            get { return (string)GetValue(ProgressTextProperty); }
            set { SetValue(ProgressTextProperty, value); }
        }
#endregion
    }
}
