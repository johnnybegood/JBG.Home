using System.Collections.Generic;

namespace JBG.Home.Server.Devices
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
