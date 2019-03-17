using Po.Devices;
using Po.Forms.Logging;
using DeviceManagerGUI.Properties;
using System.IO.Ports;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		public DeviceCollection Devices;

		private void SaveDevices()
		{
			Settings.Default.Saved_DeviceNames = new System.Collections.Specialized.StringCollection();
			Settings.Default.Saved_Ports = new System.Collections.Specialized.StringCollection();
			Settings.Default.Saved_Descriptions = new System.Collections.Specialized.StringCollection();
			Settings.Default.Saved_FileNames = new System.Collections.Specialized.StringCollection();
			Settings.Default.Saved_Modes = new System.Collections.Specialized.StringCollection();
			Settings.Default.Saved_DeviceTypes = new System.Collections.Specialized.StringCollection();

			foreach (var device in Devices)
			{
				Settings.Default.Saved_DeviceNames.Add(device.DeviceName);
				Settings.Default.Saved_Ports.Add(device.ComPort);
				Settings.Default.Saved_Descriptions.Add(device.Description);
				Settings.Default.Saved_FileNames.Add(device.FileName);
				Settings.Default.Saved_Modes.Add(((int)device.DeviceMode).ToString());
				Settings.Default.Saved_DeviceTypes.Add(((int)device.DeviceType).ToString());
			}

			Settings.Default.Save();
		}
		private void LoadDevices()
		{
			if (Settings.Default.Saved_Ports == null)
			{
				return;
			}

			try
			{
				for (int i = 0; i < Settings.Default.Saved_Ports.Count; i++)
				{
                    Devices.Add(
                        Settings.Default.Saved_DeviceNames[i],
                        Settings.Default.Saved_DeviceTypes[i].TryGetDeviceType(),
                        Settings.Default.Saved_Ports[i],
                        Settings.Default.Saved_Descriptions[i],
                        Settings.Default.Saved_FileNames[i],
                        0);// (int)Settings.Default.Saved_Modes[i].TryGetDeviceMode()); // TODO: implement TryGetDeviceMode 
                }

				UpdateAvailablePortsTooltip(SerialPort.GetPortNames());
				UpdateDeviceStates(SerialPort.GetPortNames());
			}
			catch
			{
				Logger.ShowMessage("Failed to load saved user devices from the last session. Clearing the save.");
				SaveDevices();
			}
			RefreshDeviceGridRows();
		}
	}
}
