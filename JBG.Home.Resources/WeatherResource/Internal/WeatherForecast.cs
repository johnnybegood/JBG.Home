using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class WeatherForecast
    {
        [JsonProperty("dt")]
        public long DateTimeTicks { get; set; }

        [JsonProperty("main")]
        public WeatherConditions Condiditions { get; set; }

        [JsonProperty("weather")]
        public WeatherDetails[] Details { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("sys")]
        public WeatherSys SystemInformation { get; set; }
    }
}