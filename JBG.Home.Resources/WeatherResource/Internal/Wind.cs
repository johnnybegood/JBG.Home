using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }
    }
}