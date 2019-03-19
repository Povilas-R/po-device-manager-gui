using Po.Devices;
using Po.Forms.Threading;
using System;
using System.Linq;

namespace DeviceManagerGUI.DataCollecting
{
    public partial class DataCollector : ThreadService
    {
        private DeviceManager _deviceManager;
        public DataCollector(DeviceManager deviceManager) : base("data-collector")
        {
            _deviceManager = deviceManager;
        }

        private int[] _deviceIds;
        public long StartTicks = DateTime.UtcNow.Ticks;

        public void Refresh()
        {
            _deviceIds = _deviceManager.Devices.Where(e => e.ConnectionState == ConnectionState.Connected).Select(e => e.ID).ToArray();
            StartTicks = DateTime.UtcNow.Ticks;

            foreach (var listener in _deviceManager.Listeners.Values)
            {
                listener.SetStartTicks(StartTicks);
            }
        }
    }
}
