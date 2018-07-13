using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JBG.Home.Server.Resources;
using Microsoft.Azure.KeyVault.Models;

namespace JBG.Home.Server.Devices
{
    public class SonyAmpDevice : IDevice
    {
        private readonly IIRSender _irSender;

        public string FullName => "Versterker beneden";

        // IR Codes
        public const string PowerToggleCode = "1,1,40000,1,1,95,24,48,24,24,24,48,24,24,24,48,24,24,24,24,24,24,24,24,24,24,24,24,24,48,1034";

        public SonyAmpDevice(IIRSender irSender)
        {
            _irSender = irSender;
        }

        [DeviceAction]
        public Task PowerToggle()
        {
            return _irSender.SendAsync(PowerToggleCode, 1);
        }
    }
}
