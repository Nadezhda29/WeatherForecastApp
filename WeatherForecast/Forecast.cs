using System;

namespace WeatherForecast
{
    class Forecast
    {
        public string date { get; set; }
        public long date_ts { get; set; }
        public int week { get; set; }
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public int moon_code { get; set; }
        public string moon_text { get; set; }

        public Parts parts { get; set; }
    }
}
