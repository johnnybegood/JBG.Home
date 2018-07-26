using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl.Http.Configuration;
using JBG.Home.Resources.WeatherResource.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JBG.Home.Resources.WeatherResource
{
    /// <summary>
    /// Weather resource. Uses <a href="https://openweathermap.org/api">OpenWeather API</a>
    /// </summary>
    public class WeatherResource : IWeatherResource
    {
        private readonly ILogger<WeatherResource> _logger;
        private readonly IFlurlClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:JBG.Home.Resources.WeatherResource.WeatherResource"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        /// <param name="clientFactory">Flurl Client factory.</param>
        /// <param name="configuration">Configuration.</param>
        public WeatherResource(ILogger<WeatherResource> logger, IFlurlClientFactory clientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _client = clientFactory.Get(configuration["Weather:Url"])
                                   .Configure(s => s.Defaults.BeforeCall = SetAppId(configuration["Weather:AppId"]));
        }

        private Action<HttpCall> SetAppId(string appId)
        {
            return call =>
            {
                call.FlurlRequest.SetQueryParam("APPID", appId);
            };
        }

        /// <inheritdoc />
        public async Task<CurrentWeatherSummary> GetCurrentWeatherAsync(int cityId)
        {
            var response = await _client.Request("weather")
                                        .SetQueryParams(new {
                                            id = cityId,
                                            units = "metric",
                                        })
                                        .GetJsonAsync<CurrentWeather>();

            return new CurrentWeatherSummary
            {
                CurrentTemperature = response.Condiditions.Temp,
                MaxTemperature = response.Condiditions.TempMax,
                MinTemperature = response.Condiditions.TempMin,
                DescriptionCurrentCondition = string.Join(", ", response.Details.Select(d => d.Description)),
                CurrentCondition = MapCurrentCondition(response.Details)
            };
        }

        /// <summary>
        /// Maps Openweathermap weather codes to <see cref="WeatherCondition"/>.
        /// See <a href="https://openweathermap.org/weather-conditions">openweathermap.org/weather-conditions</a> for more information on the weather codes.
        /// </summary>
        /// <returns>The current condition.</returns>
        /// <param name="details">Openweathermap weather details</param>
        private WeatherCondition MapCurrentCondition(WeatherDetails[] details)
        {
            var condition = WeatherCondition.Clear;

            foreach (var item in details)
            {
                switch (item.Id)
                {
                    case var id when id >= 200 && id < 300:
                        condition &= WeatherCondition.Thunderstorm;
                        break;
                    case var id when id >= 300 && id < 400:
                        condition &= WeatherCondition.Drizzle;
                        break;
                    case var id when id >= 500 && id < 600:
                        condition &= WeatherCondition.Rain;
                        break;
                    case var id when id >= 600 && id < 700:
                        condition &= WeatherCondition.Snow;
                        break;
                    case var id when id >= 700 && id < 800:
                        condition &= WeatherCondition.Fog;
                        break;
                    case var id when id > 801 && id < 900:
                        condition &= WeatherCondition.Clouds;
                        break;
                    default:
                        break;
                }
            }

            return condition;
        }
    }
}
