using System;
using System.Linq;

namespace JBG.Home.Resources.WeatherResource.Internal
{
    internal static class WeatherResourceExtensions
    {
        internal static DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        /// <summary>
        /// Map Unix timestamp to local <see cref="DateTime"/>
        /// </summary>
        /// <returns>The to date time.</returns>
        /// <param name="ticks">Ticks.</param>
        internal static DateTime MapToDateTime(this long ticks)
        {
            return Epoch.AddSeconds(ticks).ToLocalTime();
        }

        /// <summary>
        /// Extension that maps <see cref="WeatherForecast"/> to <see cref="WeatherSummary"/>.
        /// </summary>
        /// <returns>The to weather summary.</returns>
        /// <param name="forecast">Forecast.</param>
        internal static WeatherSummary MapToWeatherSummary(this WeatherForecast forecast)
        {
            if (forecast == null)
            {
                throw new ArgumentNullException(nameof(forecast));
            }

            return new WeatherSummary
            {
                Condition = forecast.Details.MapToCondition(),
                DescriptionCondition = String.Join(", ", forecast.Details.Select(d => d.Description)),
                ForecastDateTime = forecast.DateTimeTicks.MapToDateTime(),
                MaxTemperature = forecast.Condiditions.TempMax,
                MinTemperature = forecast.Condiditions.TempMin,
                Sunrise = forecast.SystemInformation.Sunrise.MapToDateTime(),
                Sunset = forecast.SystemInformation.Sunset.MapToDateTime(),
            };
        }

        /// <summary>
        /// Maps Openweathermap weather codes to <see cref="WeatherCondition"/>.
        /// See <a href="https://openweathermap.org/weather-conditions">openweathermap.org/weather-conditions</a> for more information on the weather codes.
        /// </summary>
        /// <returns>The current condition.</returns>
        /// <param name="details">Openweathermap weather details</param>
        internal static WeatherCondition MapToCondition(this WeatherDetails[] details)
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
