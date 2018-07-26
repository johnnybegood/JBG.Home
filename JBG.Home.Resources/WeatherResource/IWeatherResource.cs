using System.Threading.Tasks;

namespace JBG.Home.Resources.WeatherResource
{
    /// <summary>
    /// Weather resource. Uses <a href="https://openweathermap.org/api">OpenWeather API</a>
    /// </summary>
    public interface IWeatherResource
    {
        /// <summary>
        /// Gets the current weather async. Uses <a href="https://openweathermap.org/current">/current</a> of OpenWeather API
        /// </summary>
        /// <returns>The current weather for the requested city async.</returns>
        /// <param name="cityId">City identifier. See <a href="https://openweathermap.org/api">OpenWeather API</a> mapping of cities and ids</param>
        Task<CurrentWeatherSummary> GetCurrentWeatherAsync(int cityId);
    }
}
