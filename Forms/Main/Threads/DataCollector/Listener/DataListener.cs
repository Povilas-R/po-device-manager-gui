using Po.Devices;
using Po.Devices.SensorBoard;
using Po.Forms.Threading;
using DeviceManagerGUI.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using static Po.Devices.Device;

namespace DeviceManagerGUI
{
	public partial class DataListener : ThreadService
	{
		private DeviceManager _deviceManager;
		public DataListener(DeviceManager deviceManager) : base("DataListener")
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
