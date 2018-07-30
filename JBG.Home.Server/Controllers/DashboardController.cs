using System;
using System.Linq;
using System.Threading.Tasks;
using JBG.Home.Resources.WeatherResource;
using JBG.Home.Server.Common;
using JBG.Home.Server.Controllers.Models;
using JBG.Home.Server.Helpers;
using JBG.Home.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JBG.Home.Server.Controllers
{
    [Route("/api/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IWeatherResource _weatherResource;
        private readonly IConfiguration _configuration;

        public DashboardController(IWeatherResource weatherResource, IConfiguration configuration)
        {
            _weatherResource = weatherResource;
            _configuration = configuration;
        }

        [Route("")]
        [HttpGet]
        [ResponseCache(CacheProfileName = CachePolicies.ShortReadCache)]
        public async Task<ActionResult<HomeDashboardResponse>> GetHomeDashboardAsync()
        {
            var response = new HomeDashboardResponse();

            var city = _configuration.GetValue<int>("Weather:City");
            var currentWeather = await _weatherResource.GetCurrentWeatherAsync(city);
            var forecast = await _weatherResource.GetForecastAsync(city);
            var today = forecast.First(f => f.ForecastDateTime.Date == DateTime.Today);

            response.Weather = new DashboardWeatherResponse
            {
                CurrentTemperature = currentWeather.CurrentTemperature.Round(1),
                MaxTodayTemperature = today.MaxTemperature.Round(1),
                MinTodayTemperature = today.MinTemperature.Round(1),
                Condition = currentWeather.Weather.Condition.MapToName(),
                Description = currentWeather.Weather.DescriptionCondition,
                Sunrise = currentWeather.Weather.Sunrise,
                Sunset = currentWeather.Weather.Sunset,
                Alert = forecast
                    .Where(f => (f.Condition & WeatherCondition.Bad) != 0)
                    .FirstOrDefault(f => f.ForecastDateTime < DateTime.Now.AddHours(48))
                    ?.Condition
                    .MapToName()
            };

            return Ok(response);
        }
    }
}
