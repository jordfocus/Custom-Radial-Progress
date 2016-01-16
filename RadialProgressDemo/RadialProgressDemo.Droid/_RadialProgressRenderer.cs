using System.ComponentModel;
using Android.Graphics;
using RadialProgressDemo;
using RadialProgressDemo.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RadialProgress), typeof(RadialProgressRenderer))]
namespace RadialProgressDemo.Droid
{
    public class RadialProgressRenderer : VisualElementRenderer<RadialProgress>
    {
        public RadialProgressRenderer()
        {
            SetWillNotDraw(false);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RadialProgress.ProgressProperty.PropertyName)
                Invalidate(); // Force a call to OnDraw
        }

        protected override void OnDraw(Canvas canvas)
        {
            var element = this.Element;
            //var rect = new Rect();
            //this.GetDrawingRect(rect);

            //var paint = new Paint()
            //{
            //    Color = Android.Graphics.Color.AliceBlue,
            //    AntiAlias = true
            //};

            //canvas.DrawOval(new RectF(rect), paint);
            var width = canvas.Width;
            var heigth = canvas.Height;
            // TODO: calculate the center of the circle...
            // take the smaller value
            if (heigth < width)
            {
                width = heigth;
            }
            var progress = element.Progress;
            var diametar = 500;
            var borderColor = element.BorderColor.ToAndroid();
            if (progress >= element.Max)
            {
                borderColor = element.MaxReachedBorderColor.ToAndroid();
            }
            var fillColor = element.FillColor.ToAndroid();
            var textColor = Android.Graphics.Color.White;
            var paint = new Paint();
            // draw border circle 
            paint.Color = borderColor;
            paint.StrokeWidth = width / 20; //30; // TODO: must be dependent from the size!!!
            paint.AntiAlias = true;
            paint.SetStyle(Paint.Style.Stroke);
            canvas.DrawCircle(width / 2, width / 2, width / 2 - 20, paint);
            // draw progress circle
            paint.Color = fillColor;
            paint.StrokeWidth = 16; // TODO: must be dependent from the size!!!
            var oval = new RectF();
            paint.SetStyle(Paint.Style.Fill);
            oval.Set(30, 30, width - 30, width - 30);
            canvas.DrawArc(oval, 270, (progress * 360) / element.Max, true, paint);
            // draw progress text
            paint.StrokeWidth = 1;
            paint.TextSize = width / 3;
            paint.TextAlign = Paint.Align.Center;
            paint.Color = textColor;
            canvas.DrawText(progress.ToString(), width / 2, width / 2 + (paint.TextSize / 3), paint);
            var mainTextPosition = width/2 + (paint.TextSize/3);
            // draw custom message
            paint.TextSize = width / 10;
            canvas.DrawText("victories", width / 2, mainTextPosition + paint.TextSize + 2, paint);
        }
    }
}