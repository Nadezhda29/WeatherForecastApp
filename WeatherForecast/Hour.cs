using System;

namespace WeatherForecast
{
    class Hour
    {
        public string time { get; set; }
        public decimal temp_c { get; set; }
        public string icon { get; set; }
        public int chance_of_rain { get; set; }
        public int chance_of_snow { get; set; }
    }
}
