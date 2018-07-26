using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class CurrentWeather
    {
        [JsonProperty("coord")]
        public WeatherCoordinates Coordinates { get; set; }

        [JsonProperty("weather")]
        public WeatherDetails[] Details { get; set; }

        [JsonProperty("main")]
        public WeatherConditions Condiditions { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public long DateTimeTicks { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}