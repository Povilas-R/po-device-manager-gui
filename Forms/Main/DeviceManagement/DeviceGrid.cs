using Po.Devices;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using static Po.Devices.Device;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		public DeviceManager DeviceManager = new DeviceManager() { EnableIndexedData = true };

		private void DataGrid_Devices_MouseClick(MouseEventArgs e)
		{
			// Updates selection and edit
			var hitTest = DataGrid_Devices.HitTest(e.X, e.Y);
			(int row, int col) = (hitTest.RowIndex, hitTest.ColumnIndex);
			if (row == -1)
			{
				DataGrid_Devices.ClearSelection();
			}
			else if (!DataGrid_Devices.Rows[row].Cells[col].IsInEditMode)
			{
				DataGrid_Devices.CancelEdit();
			}

			// Context menu
			if (e.Button == MouseButtons.Right)
			{
				if (row != -1)
				{
					if (!DataGrid_Devices.Rows[row].Selected)
					{
						DataGrid_Devices.ClearSelection();
					}

					DataGrid_Devices.Rows[row].Selected = true;
					GridMenu.Show(Cursor.Position);
				}
			}
		}

		private bool _isEditingCell = false;
		private void EnterCellEdit(DataGridViewCellCancelEventArgs e)
		{
			_isEditingCell = Devices[e.RowIndex].ConnectionState == ConnectionState.Unavailable || Devices[e.RowIndex].ConnectionState == ConnectionState.Disconnected;
			e.Cancel = !_isEditingCell;
		}
		private void TryEndCellEdit()
		{
			if (!_isEditingCell)
			{
				return;
			}
			_isEditingCell = false;

			var cell = DataGrid_Devices.CurrentCell;
			int rowIndex = cell.RowIndex;

			// Device name
			if (cell.OwningColumn == Column_DeviceName)
			{
				string name = ((string)cell.Value).GetDeviceName();
				if (CheckDeviceName(name, true, Devices[rowIndex].DeviceName))
				{
					Devices[rowIndex].DeviceName = name;
				}
			}
			// COM port
			if (cell.OwningColumn == Column_Port)
			{
				string port = ((string)cell.Value).GetPort();
				if (CheckPort(port, true, Devices[rowIndex].ComPort))
				{
					Devices[rowIndex].ComPort = port;
				}
			}
			// Description
			else if (cell.OwningColumn == Column_Description)
			{
				Devices[rowIndex].Description = (string)cell.Value;
			}
			// File name
			else if (cell.OwningColumn == Column_FileName)
			{
				string fileName = ((string)cell.Value).GetFileName("csv", "txt");
				if (CheckFileName(fileName, true, Devices[rowIndex].FileName))
				{
					Devices[rowIndex].FileName = fileName;
				}
			}

			if (cell.OwningColumn != Column_Port
				|| !UpdateAvailablePorts(SerialPort.GetPortNames()))
			{
				RefreshDeviceGridRows();
			}
			DataGrid_Devices.Rows[rowIndex].Selected = true;
		}
		
		public void InvokeDeviceGridUpdate()
		{
			try
			{
				if (IsHandleCreated)
				{
					if (!_isFormClosing)
					{
						BeginInvoke((MethodInvoker)delegate
						{
							RefreshDeviceGridRows();
						});
					}
				}
				else
				{
					RefreshDeviceGridRows();
				}
			}
			catch { }
		}

		public void RefreshDeviceGridRows()
		{
			var selectedDevices = new List<Device>();
			for (int i = 0; i < DataGrid_Devices.Rows.Count && i < Devices.Count; i++)
			{
				if (DataGrid_Devices.Rows[i].Selected)
				{
					selectedDevices.Add(Devices[i]);
				}
			}

			Devices.Sort((x, y) => x.ID.CompareTo(y.ID));

			DataGrid_Devices.Rows.Clear();
			for (int i = 0; i < Devices.Count; i++)
			{
				string deviceTypeColumnText = Devices[i].DeviceType.ToString();
				DataGrid_Devices.Rows.Add(deviceTypeColumnText, Devices[i].DeviceName, Devices[i].ComPort, Devices[i].ConnectionState.ToString(), Devices[i].Description, Devices[i].FileName);
			}

			UpdateDeviceGridStyle();
			for (int i = 0; i < DataGrid_Devices.Rows.Count && i < Devices.Count; i++)
			{
				DataGrid_Devices.Rows[i].Selected = selectedDevices.Contains(Devices[i]);
			}

			UpdateDataCollectorButton();

			SaveDevices();
		}
		
		private void UpdateDeviceGridStyle()
		{
			for (int i = 0; i < Devices.Count; i++)
			{
				if (Devices[i].ConnectionState == ConnectionState.Connected)
				{
					DataGrid_Devices.Rows[i].DefaultCellStyle.BackColor = Color.PaleGreen;
					DataGrid_Devices.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Green;
				}
				else if (Devices[i].ConnectionState == ConnectionState.Disconnected)
				{
					DataGrid_Devices.Rows[i].DefaultCellStyle.BackColor = SystemColors.Control;
					DataGrid_Devices.Rows[i].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
				}
				else if (Devices[i].ConnectionState == ConnectionState.Unavailable)
				{
					DataGrid_Devices.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
					DataGrid_Devices.Rows[i].DefaultCellStyle.SelectionBackColor = Color.Red;
				}
				else
				{
					DataGrid_Devices.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
					DataGrid_Devices.Rows[i].DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
				}
			}
		}
	}
}
