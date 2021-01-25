using System;

namespace WeatherForecast
{
    class Current
    {
        public decimal temp_c { get; set; }
        public Condition condition { get; set; }
        public decimal feelslike_c { get; set; }
        public decimal uv { get; set; }

    }
}
