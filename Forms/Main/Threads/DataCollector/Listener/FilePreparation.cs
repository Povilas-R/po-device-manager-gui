using Po.Devices;
using DeviceManagerGUI.Properties;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static Po.Devices.Device;

namespace DeviceManagerGUI
{
	public partial class DataListener
	{
		public bool PrepareOutputDirectory()
		{
			// Creates output directory if missing
			Directory.CreateDirectory(Settings.Default.OutputDirectory);

			// Checks for incompatible data files
			foreach (int id in _deviceIds)
			{
				var device = _deviceManager.Devices.GetDevice(id);

				string filePath = Path.Combine(Settings.Default.OutputDirectory, device.FileName);
				while (!CheckFileCompatibility(filePath, device, out string errorText))
				{
					string warningText =
						$"\"{filePath}\" file is incompatible for appending {_deviceManager.Listeners[id].Device.DeviceName} data to it." +
						errorText +
						$"\nEdit, move, rename or delete the file to continue.";
					if (MessageBox.Show(warningText, "Incompatible file", MessageBoxButtons.RetryCancel) == DialogResult.Cancel)
					{
						return false;
					}
				}
            }

			return true;
		}

        private bool CheckFileCompatibility(string filePath, Device device, out string errorText)
		{
            try
            {
				var iniLines = InitializeFile(filePath, device);
				string[] lines = File.ReadAllLines(filePath);
				string port = device.ComPort;

				if (lines.Length < RowIndexes.FirstDataRow)
				{
					errorText = $"\nExpected at least {RowIndexes.FirstDataRow} lines, but the file only has {lines.Length} lines.";
					return false;
				}

				errorText =
					(lines[RowIndexes.DeviceName].Trim() != device.DeviceName
					? $"\nExpected \"{device.DeviceName}\" device name in line {RowIndexes.DeviceName + 1}." : string.Empty) +
                    // TODO: add distinction between TCP and Serial
					(lines[RowIndexes.Port].Trim() != port
					? $"\nExpected \"{port}\" port in line {RowIndexes.Port + 1}." : "") +

					(lines[RowIndexes.TypeString].Trim() != iniLines.Type
					? $"\nExpected \"{iniLines.Type}\" device type in line {RowIndexes.TypeString + 1}." : string.Empty) +

					(lines[RowIndexes.Headers].Trim() != iniLines.Header
					? $"\nExpected different headers in line {RowIndexes.Headers + 1}." : string.Empty);
			}
			catch (Exception ex)
			{
				errorText = ex.Message;
			}

			return string.IsNullOrEmpty(errorText);
		}
		private (string Header, string Type) InitializeFile(string filePath, Device device)
		{
			string typeString = $"{device.DeviceType.ToString()}";
			string headerLine = GetHeaderLine(device.DeviceType, device.DeviceMode);
			if (!File.Exists(filePath))
			{
				string infoLines = $"{device.DeviceName}\n{device.ComPort}\n{device.Description}\n{typeString}\n"; 
                // TODO: add distinction between serial and tcp communication
				File.WriteAllText(filePath, infoLines + headerLine + "\n");
			}

			return (headerLine, typeString);
		}
		private string GetHeaderLine(DeviceType type, int mode, bool ignoreTime = false)
		{
			if (type == DeviceType.SensorBoard)
			{
				return
					(!ignoreTime ? (Settings.Default.Column_Millis + ",") : "") +
					(!ignoreTime ? (Settings.Default.Column_TicksUTC + ",") : "") +
					(!ignoreTime ? (Settings.Default.Column_DateUTC + ",") : "") +
					(!ignoreTime ? (Settings.Default.Column_DateLocal + ",") : "") +
					Settings.Default.Column_Index + "," +
					Settings.Default.BoardColumn_Pressure1 + "," +
					Settings.Default.BoardColumn_Pressure2 + "," +
					Settings.Default.BoardColumn_Pressure3 + "," +
					Settings.Default.BoardColumn_Pressure4 + "," +
					Settings.Default.BoardColumn_Pressure5 + "," +
					Settings.Default.BoardColumn_Pressure6 + "," +
					Settings.Default.BoardColumn_Pressure7 + "," +
					Settings.Default.BoardColumn_Pressure8 + "," +
					Settings.Default.BoardColumn_O2Volts1 + "," +
					Settings.Default.BoardColumn_O2Volts2;
			}
            else
            {
                return string.Empty;
            }
		}

		private string GetNamesLine(DeviceType type, int mode = 0)
		{
			string namesLine = "";
			foreach (string name in _deviceManager.Devices.Where(e => 
				e.DeviceType == type 
				&& e.DeviceMode == mode
				&& e.ConnectionState == ConnectionState.Connected)
			.Select(e => e.DeviceName))
			{
				namesLine += name + ",";
			}

			return namesLine;
		}
		private string GetPortsLine(DeviceType type, int mode = 0)
		{
			string portsLine = "";
			foreach (string port in _deviceManager.Devices.Where(e => 
				e.DeviceType == type
				&& e.DeviceMode == (int)mode
				&& e.ConnectionState == ConnectionState.Connected)
			.Select(e => e.ComPort))
			{
				portsLine += port + ",";
			}

			return portsLine;
		}
		private (string Names, string Headers) GetHeaderLines(DeviceType type, int mode = 0)
		{
			string headerLine = GetHeaderLine(type, mode, true);
			int columnCount = headerLine.Where(e => e == ',').Count() + 1;
			string headerLine1 = "";
			string headerLine2 = "";
			foreach (var device in _deviceManager.Devices.Where(e =>
				e.DeviceType == type
				&& e.DeviceMode == mode
				&& e.ConnectionState == ConnectionState.Connected))
			{
				for (int i = 0; i < columnCount; i++)
				{
					if (i == 0)
					{
						headerLine1 += device.DeviceName;
					}
					headerLine1 += ",";
				}
				headerLine2 += headerLine + ",";
			}
			return (headerLine1, headerLine2);
		}
	}
}
