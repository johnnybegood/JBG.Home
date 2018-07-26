using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class WeatherCoordinates
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}