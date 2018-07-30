using System;

namespace JBG.Home.Server.Controllers.Models
{
    public class DashboardWeatherResponse
    {
        public double CurrentTemperature { get; set; }
        public double MaxTodayTemperature { get; set; }
        public double MinTodayTemperature { get; set; }
        public string Condition { get; set; }
        public string Description { get; set; }
        public string Alert { get; internal set; }
        public DateTime Sunrise { get; internal set; }
        public DateTime Sunset { get; internal set; }
    }
}