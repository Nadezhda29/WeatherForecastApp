using System;

namespace WeatherForecast
{
    class Forecastday
    {
        public string date { get; set; }
        public Day day { get; set; }
        public Astro astro { get; set; }

        public Hour[] hours { get; set; }
    }
}
