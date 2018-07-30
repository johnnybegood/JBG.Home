using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class CurrentWeather : WeatherForecast
    {
        [JsonProperty("coord")]
        public WeatherCoordinates Coordinates { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}