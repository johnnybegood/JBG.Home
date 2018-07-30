using System;

namespace JBG.Home.Resources.WeatherResource
{
    public class WeatherSummary
    {
        public DateTime ForecastDateTime { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public WeatherCondition Condition { get; set; }
        public string DescriptionCondition { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
    }
}