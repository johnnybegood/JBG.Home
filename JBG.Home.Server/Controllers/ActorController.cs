using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBG.Home.DeviceManagement;
using JBG.Home.DeviceManagement.Contracts;
using JBG.Home.Resources.IRResource;
using Microsoft.AspNetCore.Mvc;

namespace JBG.Home.Server.Controllers
{
    [Route("api/[controller]")]
    public class ActorController : Controller
    {
        private readonly IDeviceManager _deviceManager;

        public ActorController(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        [HttpGet]
        public IDictionary<string, string> Get()
        {
            return _deviceManager.AllDevices()
                .ToDictionary(d => d.GetType().Name, d => d.FullName);
        }

        [HttpGet("{id}")]
        public string[] Get(string deviceName)
        {
            var deviceType = Type.GetType(deviceName);
            return DeviceActions.For(deviceType);
        }

        [HttpPost("trigger/{actionId}")]
        public async Task TriggerAction(string actionId)
        {
            //TODO: make generic
            using (var irSender = new IRSender("192.168.1.8"))
            {
               await irSender.SendAsync("sendir,1:1,1,40000,1,1,95,24,48,24,24,24,48,24,24,24,48,24,24,24,24,24,24,24,24,24,24,24,24,24,48,1034", 1);
                
            }
        }
    }
}
