using System;

namespace WeatherForecast
{
    class Fact
    {
        public int temp { get; set; }
        public int feels_like { get; set; }
        public int temp_water { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public int wind_speed { get; set; }
        public int wind_guest { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public string season { get; set; }
        public long obs_time { get; set; }
    }
}
