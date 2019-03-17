using Po.Devices;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using static Po.Devices.Device;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		private void UpdateAvailablePortsTooltip(string[] ports)
		{
			_availablePortsTooltip = null;
			var usedPorts = Devices.Select(e => e.ComPort);
			foreach (string port in ports)
			{
				if (!usedPorts.Contains(port))
				{
					_availablePortsTooltip += port + " ";
				}
			}

			_availablePortsTooltip = "Available ports: " + (_availablePortsTooltip ?? "none");
			if (StatusBar_ToolTip.Text?.Contains("Available ports: ") ?? false)
			{
				UpdateStatusBar(_availablePortsTooltip);
			}
		}
		private bool UpdateDeviceStates(string[] ports)
		{
			bool statesChanged = false;

			for (int i = 0; i < Devices.Count; i++)
			{
				if (!ports.Contains(Devices[i].ComPort))
				{
					if (Devices[i].ConnectionState != ConnectionState.Unavailable)
					{
						statesChanged = true;
						Devices[i].ConnectionState = ConnectionState.Unavailable;
					}
				}
				else if (Devices[i].ConnectionState == ConnectionState.Unavailable)
				{
					statesChanged = true;
					Devices[i].ConnectionState = ConnectionState.Disconnected;
				}
			}

			return statesChanged;
		}

		public bool UpdateAvailablePorts(string[] ports)
		{
			UpdateAvailablePortsTooltip(ports);

			if (UpdateDeviceStates(ports))
			{
				RefreshDeviceGridRows();
				return true;
			}
			return false;
		}
	}
}
