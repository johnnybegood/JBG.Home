using System;

namespace JBG.Home.Resources.WeatherResource
{
    [Flags]
    public enum WeatherCondition
    {
        Clear = 0,
        Sun = 1,
        Thunderstorm = 2,
        Drizzle = 4,
        Rain = 8,
        Snow = 16,
        Fog = 24,
        Clouds = 36,
    }
}