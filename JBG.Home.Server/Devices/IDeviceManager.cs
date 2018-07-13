using System.Collections.Generic;

namespace JBG.Home.Server.Devices
{
    public interface IDeviceManager
    {
        IReadOnlyCollection<IDevice> AllDevices();
    }
}