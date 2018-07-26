namespace JBG.Home.Resources.WeatherResource
{
    public class CurrentWeatherSummary
    {
        public double CurrentTemperature { get; set; }
        public double MinTemperature { get; set; }
        public double MaxTemperature { get; set; }
        public WeatherCondition CurrentCondition { get; set; }
        public string DescriptionCurrentCondition { get; set; }
    }
}