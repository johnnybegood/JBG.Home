using System;
using System.Linq;

namespace JBG.Home.Server.Devices
{
    public static class DeviceActions
    {
        /// <summary>
        /// Get all actions for the given device type
        /// </summary>
        /// <typeparam name="TDevice"></typeparam>
        /// <returns></returns>
        public static string[] For<TDevice>() where TDevice : IDevice
        {
            return For(typeof(TDevice));
        }

        public static string[] For(Type deviceType)
        {
            if (!deviceType.IsAssignableFrom(typeof(IDevice)))
            {
                throw new ArgumentException("DeviceType must be of type IDevice", nameof(deviceType));
            }

            var actions = deviceType.GetMethods()
                .Where(m => m.CustomAttributes.Any(c => c.AttributeType == typeof(DeviceActionAttribute)))
                .Select(m => m.Name)
                .ToArray();

            return actions;
        }
    }

    public class DeviceActionAttribute : Attribute
    {
    }
}