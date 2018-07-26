using System.Collections.Generic;
using JBG.Home.DeviceManagement.Contracts;

namespace JBG.Home.Server.DeviceManagement
{
    public class DeviceManager : IDeviceManager
    {
        private readonly IDevice[] _devices;

        public DeviceManager(IDevice[] devices)
        {
            _devices = devices;
        }
        public IReadOnlyCollection<IDevice> AllDevices()
        {
            return _devices;
        }
    }
}
