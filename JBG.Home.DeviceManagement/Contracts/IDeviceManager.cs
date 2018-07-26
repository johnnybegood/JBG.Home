using System.Collections.Generic;

namespace JBG.Home.DeviceManagement.Contracts
{
    public interface IDeviceManager
    {
        IReadOnlyCollection<IDevice> AllDevices();
    }
}