using Po.Devices;
using Po.Forms.Logging;
using DeviceManagerGUI.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using Po.Forms;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        private void UpdateDataGridContextMenu()
        {
            var selectedCount = getSelectedCount();
            var typeCount = getTypeCount();

            //GridMenu_Remove.Enabled = _dataCollectorWorker == null || !_dataCollectorWorker.IsBusy;
            //GridMenu_Connection.Enabled = _dataCollectorWorker == null || !_dataCollectorWorker.IsBusy;
            GridMenu_Connect.Enabled = selectedCount.Disconnected > 0;
            GridMenu_Disconnect.Enabled = selectedCount.Connected > 0;
            GridMenu_Configure.Enabled =
                !_dataCollector.IsRunning
                && selectedCount.Connected == 1
                && selectedCount.Disconnected == 0;

            GridMenu_Configure.Visible = typeCount.SensorBoard == 0;
            GridMenu_Watch.Visible = typeCount.SensorBoard == 0;

            (int Connected, int Disconnected) getSelectedCount()
            {
                int selectedConnectedCount = 0;
                int selectedDisconnectedCount = 0;
                for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
                {
                    if (DataGrid_Devices.Rows[i].Selected)
                    {
                        if (Devices[i].ConnectionState == ConnectionState.Connected || Devices[i].ConnectionState == ConnectionState.Unknown)
                        {
                            selectedConnectedCount++;
                        }
                        else if (Devices[i].ConnectionState == ConnectionState.Disconnected)
                        {
                            selectedDisconnectedCount++;
                        }
                    }
                }

                return (selectedConnectedCount, selectedDisconnectedCount);
            }

            (int SensorBoard, int Other) getTypeCount()
            {
                int boardCount = 0;
                int otherCount = 0;

                for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
                {
                    if (DataGrid_Devices.Rows[i].Selected)
                    {
                        if (Devices[i].DeviceType == DeviceType.SensorBoard)
                        {
                            boardCount++;
                        }
                        else
                        {
                            otherCount++;
                        }
                    }
                }

                return (boardCount, otherCount);
            }
        }

        /// <summary>
        /// Currently does nothing.
        /// </summary>
        private void WatchSelectedDevices()
        {
            var files = new List<string>();
            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                if (DataGrid_Devices.Rows[i].Selected)
                {
                    files.Add(Path.Combine(Settings.Default.OutputDirectory, Devices[i].FileName));
                }
            }

            //RunAsync(() => { new MyViewerForm(files).Show(); });
        }
        private void LiveWatchSelectedDevices()
        {
            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                int id = Devices[i].ID;
                if (DataGrid_Devices.Rows[i].Selected)
                {
                    if (!LiveListeners.ContainsKey(id) || !LiveListeners[id].IsRunning)
                    {
                        StartLiveWatchListener(id);
                    }
                    else
                    {
                        LiveListeners[id].FocusWindow();
                    }
                }
            }
        }
        private void RemoveSelectedDevices()
        {
            int devicesRemoved = 0;
            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                if (DataGrid_Devices.Rows[i].Selected)
                {
                    if (MessageBox.Show("Are you sure you want to remove this device?", $"{Devices[i - devicesRemoved].DeviceName} removal confirmation", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        continue;
                    }

                    DeviceManager.RemoveListener(Devices[i - devicesRemoved].ID);
                    Devices.RemoveAt(i - devicesRemoved++);
                }
            }
            UpdateAvailablePortsTooltip(SerialPort.GetPortNames());

            RefreshDeviceGridRows();
        }
        private void ConnectToSelectedDevices()
        {
            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                if (DataGrid_Devices.Rows[i].Selected
                    && Devices[i].ConnectionState == ConnectionState.Disconnected)
                {
                    try
                    {
                        DeviceManager.AddListener(
                            Devices[i], MessageCallHandler, ConnectionChangedHandler, DataReceivedHandler);
                        DeviceManager.StartListener(Devices[i].ID);
                        if (_dataCollector != null)
                        {
                            DeviceManager.Listeners[Devices[i].ID].SetStartTicks(_dataCollector.StartTicks);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.Message);
                    }
                }
            }
            RefreshDeviceGridRows();
        }
        private void DisconnectFromSelectedDevices()
        {
            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                if (DataGrid_Devices.Rows[i].Selected)
                {
                    DeviceManager.RemoveListener(Devices[i].ID);
                }
            }
            RefreshDeviceGridRows();
        }
        private void ConfigureSelectedDevices()
        {
            //var configurationForm = new ConfigurationForm();
            //var dialogResult = configurationForm.ShowDialog();
            //if (dialogResult != DialogResult.OK && dialogResult != DialogResult.Yes)
            //{
            //	return;
            //}
            //var config = configurationForm.Configuration;
            // TODO: implement device configuration form

            for (int i = 0; i < DataGrid_Devices.Rows.Count; i++)
            {
                if (DataGrid_Devices.Rows[i].Selected)
                {
                    // TODO: add device configurations here
                }
            }
            RefreshDeviceGridRows();
        }
    }
}
