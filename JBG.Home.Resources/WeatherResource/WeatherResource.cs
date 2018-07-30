using System;
using System.Collections.Generic;
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
                                   .Configure(s => s.Defaults.BeforeCall = SetDefaultQuery(configuration["Weather:AppId"], configuration["Weather:Language"]));
        }

        /// <summary>
        /// Set default query string parameters on each request
        /// </summary>
        /// <returns><see cref="Action{T}"/> to modify the <see cref="HttpCall"/>.</returns>
        /// <param name="appId">App identifier.</param>
        /// <param name="language">Language.</param>
        private Action<HttpCall> SetDefaultQuery(string appId, string language)
        {
            return call =>
            {
                call.FlurlRequest.SetQueryParam("APPID", appId);

                if(!string.IsNullOrEmpty(language)) {
                    call.FlurlRequest.SetQueryParam("lang", language);
                }
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
                Weather = response.MapToWeatherSummary(),
            };
        }

        /// <inheritdoc />
        public async Task<IEnumerable<WeatherSummary>> GetForecastAsync(int cityId)
        {
            var response = await _client.Request("forecast")
                                        .SetQueryParams(new
                                        {
                                            id = cityId,
                                            units = "metric",
                                        })
                                        .GetJsonAsync<WeatherForecastList>();

            return response
                .Items
                .Select(f => f.MapToWeatherSummary())
                .OrderBy(s => s.ForecastDateTime);
        }
    }
}
