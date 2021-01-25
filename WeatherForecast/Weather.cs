using System;

namespace WeatherForecast
{
    class Weather
    {
        public Location location { get; set; }
        public Current current { get; set; }
        public Forecast forecast { get; set; }
    }
}
