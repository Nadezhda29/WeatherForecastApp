using System;
using System.Drawing;

namespace WeatherForecast
{
    class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public Bitmap Icon
        {
            get { return new Bitmap(Image.FromFile($"icon/{icon}.png")); }
        }
    }
}
