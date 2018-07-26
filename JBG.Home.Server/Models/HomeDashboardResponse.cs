using System;
using JBG.Home.Server.Controllers.Models;

namespace JBG.Home.Server.Models
{
    public class HomeDashboardResponse
    {
        public DashboardWeatherResponse Weather { get; internal set; }
    }
}
