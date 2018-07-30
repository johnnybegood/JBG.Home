using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal class WeatherForecastList
    {
        [JsonProperty("cnt")]
        public uint Count { get; set; }

        [JsonProperty("list")]
        public IEnumerable<WeatherForecast> Items { get; set; }
    }
}