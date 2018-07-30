using System;
using JBG.Home.Resources.WeatherResource;

namespace JBG.Home.Server.Helpers
{
    public static class MappingExtensions
    {

        public static string MapToName(this WeatherCondition condition)
        {
            return Enum.GetName(typeof(WeatherCondition), condition);
        }

        public static double Round(this double number, int decimals) {
            return Math.Round(number, decimals);
        }
    }
}
