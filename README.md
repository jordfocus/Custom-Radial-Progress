# Custom-Radial-Progress
Custom implementation of Xamarin.Forms Radial Progress control

![alt tag](https://dotjord.files.wordpress.com/2016/01/radialprogressdemo2.png?w=720)

This example demonstrates how you can create custom control in Xamarin.Forms. Almost everything is adjustable on the control so you can set:

- Max value
- Border Color
- Fill Color
- Max Reached Border Color
- Progress Text
- Progress Type (Percentage or Progress)
- Text Color

Here is a sample code how can make instance of the radial progress control and setting some of the properties as we want :

var radialProgressStats1 = new RadialProgress
{
Progress = 81,
Diameter = 100,
BorderColor = Color.Blue,
FillColor = Color.Green,
TextColor = Color.White,
DisplayMode = DisplayModeTypes.ShowPercentage
}; 

Read more on https://dotjord.wordpress.com/ or just run the demo to see how this works.
![alt tag](https://dotjord.files.wordpress.com/2016/01/radialprogresscolor.png?w=720)
