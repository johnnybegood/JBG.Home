using System;
using System.Linq;
using JBG.Home.DeviceManagement.Contracts;

namespace JBG.Home.DeviceManagement
{
    public static class DeviceActions
    {
        /// <summary>
        /// Get all actions for the given device type
        /// </summary>
        /// <typeparam name="TDevice">Type of the device</typeparam>
        /// <returns></returns>
        public static string[] For<TDevice>() where TDevice : IDevice
        {
            return For(typeof(TDevice));
        }

        /// <summary>
        /// Get all actions for the given device type
        /// </summary>
        /// <param name="deviceType">Type of the device</param>
        /// <returns></returns>
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
}