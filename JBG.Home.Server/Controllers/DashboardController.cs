using System;
using System.Threading.Tasks;
using JBG.Home.Resources.WeatherResource;
using JBG.Home.Server.Common;
using JBG.Home.Server.Controllers.Models;
using JBG.Home.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JBG.Home.Server.Controllers
{
    [Route("/dashboard")]
    public class DashboardController : Controller
    {
        private readonly IWeatherResource _weatherResource;
        private readonly IConfiguration _configuration;

        public DashboardController(IWeatherResource weatherResource, IConfiguration configuration)
        {
            _weatherResource = weatherResource;
            _configuration = configuration;
        }

        [Route("home")]
        [HttpGet]
        [ResponseCache(CacheProfileName = CachePolicies.ShortReadCache)]
        public async Task<ActionResult<HomeDashboardResponse>> GetHomeDashboardAsync()
        {
            var response = new HomeDashboardResponse();

            var city = _configuration.GetValue<int>("Weather:City");
            var currentWeather = await _weatherResource.GetCurrentWeatherAsync(city);
            response.Weather = new DashboardWeatherResponse
            {
                CurrentTemperature = currentWeather.CurrentTemperature,
                MaxTodayTemperature = currentWeather.MaxTemperature,
                MinTodayTemperature = currentWeather.MinTemperature,
                Condition = Enum.GetName(typeof(WeatherCondition), currentWeather.CurrentCondition),
                Description = currentWeather.DescriptionCurrentCondition
            };

            return Ok(response);
        }
    }
}
