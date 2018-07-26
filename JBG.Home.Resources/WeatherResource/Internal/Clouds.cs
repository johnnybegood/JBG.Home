using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}