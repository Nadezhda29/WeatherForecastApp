using System;
using System.Drawing;

namespace WeatherForecast
{
    class Condition
    {
        public string text { get; set; }

        public string icon { get; set; }

        public Bitmap bitmap { get { return new Bitmap(Image.FromFile($@"C:\Users\Nadezhda\Desktop\C#\WeatherForecast\{icon.Substring(21)}")); } }
    }
}
