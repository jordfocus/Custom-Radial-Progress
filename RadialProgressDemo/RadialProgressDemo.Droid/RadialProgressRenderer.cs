using System.ComponentModel;
using Android.Graphics;
using RadialProgressDemo;
using RadialProgressDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RadialProgress), typeof(RadialProgressRenderer))]
namespace RadialProgressDemo.Droid
{
    /// <summary>
    /// Implementation of Android custom renderer for RadialProgress
    /// </summary>
    public class RadialProgressRenderer : VisualElementRenderer<RadialProgress>
    {
        /// <summary>
        /// RadialProgressRenderer constructor
        /// </summary>
        public RadialProgressRenderer()
        {
            SetWillNotDraw(false);
        }
        /// <summary>
        /// Override of the OnElementPropertyChanged. We are using this method to track all bindable 
        /// properties changes in RadialProgress
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RadialProgress.ProgressProperty.PropertyName
                || e.PropertyName == RadialProgress.BorderColorProperty.PropertyName
                || e.PropertyName == RadialProgress.FillColorProperty.PropertyName
                || e.PropertyName == RadialProgress.MaxReachedColorProperty.PropertyName
                || e.PropertyName == RadialProgress.TextColorProperty.PropertyName
                || e.PropertyName == RadialProgress.DisplayModeProperty.PropertyName
                || e.PropertyName == RadialProgress.ProgressTextProperty.PropertyName)
            {
                // Force a call to OnDraw
                Invalidate(); 
            }
                    
        }
        /// <summary>
        /// We use this method to draw the control according to property values
        /// </summary>
        /// <param name="canvas">The canvas on which the control will be drawn</param>
        protected override void OnDraw(Canvas canvas)
        {
            var element = this.Element;

            float centerX = 0;
            float centerY = 0;
            float radius = 0;
            float strokeWidth = 30;

            float horizontalOffSet;
            float verticalOffSet;
            centerX = (float)canvas.Width / 2;
            centerY = (float)canvas.Height / 2;

            if (canvas.Width > canvas.Height)
            {
                strokeWidth = (float)canvas.Height / 20;
                radius = (float)canvas.Height / 2 - strokeWidth;
                horizontalOffSet = (float)canvas.Width / 2 - (float)canvas.Height / 2 + strokeWidth + strokeWidth/2;
                verticalOffSet = strokeWidth + strokeWidth / 2; 
            }
            else
            {
                strokeWidth = (float)canvas.Width / 20;
                radius = (float)canvas.Width / 2 - strokeWidth;
                verticalOffSet = (float)canvas.Height / 2 - (float)canvas.Width / 2 + strokeWidth + strokeWidth / 2;
                horizontalOffSet = strokeWidth + strokeWidth / 2;
            }
            var progress = element.Progress;
            var borderColor = element.BorderColor.ToAndroid();
            if (progress >= element.Max)
            {
                borderColor = element.MaxReachedBorderColor.ToAndroid();
            }
            var fillColor = element.FillColor.ToAndroid();
            var paint = new Paint();
            // draw border circle 
            paint.Color = borderColor;
            paint.StrokeWidth = strokeWidth;
            paint.AntiAlias = true;
            paint.SetStyle(Paint.Style.Stroke);
            canvas.DrawCircle(centerX, centerY, radius, paint);
            // draw progress circle
            paint.Color = fillColor;
            var oval = new RectF();
            paint.SetStyle(Paint.Style.Fill);
            var progressRadialPercentage = (float) (progress*360)/element.Max;
            float startAngle = 270;
            oval.Set(horizontalOffSet, verticalOffSet, canvas.Width - horizontalOffSet, canvas.Height - verticalOffSet);
            canvas.DrawArc(oval, startAngle, progressRadialPercentage, true, paint);
            // draw progress text
            paint.StrokeWidth = 1;
            paint.TextSize = (radius*2) / 3;
            paint.TextAlign = Paint.Align.Center;
            paint.Color = element.TextColor.ToAndroid();

            var displayText = string.Empty;
            if (element.DisplayMode == DisplayModeTypes.ShowProgress)
            {
                displayText = progress.ToString();
            }
            else if (element.DisplayMode == DisplayModeTypes.ShowPercentage)
            {
                displayText = ((float)(progress * 100)/element.Max) + "%";
            }
            canvas.DrawText(displayText, centerX, centerY + (paint.TextSize / 3), paint);
            var mainTextPosition = centerY + (paint.TextSize / 3);
            // draw custom message
            paint.TextSize = (radius * 2) / 10;
            canvas.DrawText(element.ProgressText, centerX, mainTextPosition + paint.TextSize + 2, paint);
        }
    }
}