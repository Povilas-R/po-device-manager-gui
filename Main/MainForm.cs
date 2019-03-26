using Po.Devices;
using Po.Forms.Logging;
using DeviceManagerGUI.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DeviceManagerGUI.UserSettings;

namespace DeviceManagerGUI
{
    public partial class MainForm : Form
    {
        private bool _isFormClosing = false;

        public MainForm()
        {
            InitializeComponent();
            Logger.LogFileName = Settings.Default.LogFileName;
            Logger.SetDefaults(this, TextBox_Log);

            refreshDevicesComboBox();
            updateStatusBar();
            HideLog(Settings.Default.HideLogOnStartup);
            updateOutputDirectory();

            Devices = DeviceManager.Devices;
            DeviceManager.RunWorkerCompleted += new EventHandler<Device>((o, e) =>
            {
                RefreshDeviceGridRows();
            });
            LoadDevices();

            InitializeEvents();
            InitializeDataCollector();

            InitializeGuiListener();
            _guiListener.Start();

            UpdateAvailablePorts(SerialPort.GetPortNames());

            void updateOutputDirectory()
            {
                if (string.IsNullOrEmpty(Settings.Default.OutputDirectory))
                {
                    Settings.Default.OutputDirectory = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
                }
            }
            void refreshDevicesComboBox()
            {
                ComboBox_Device.Items.Clear();
                foreach (string typeName in Enum.GetNames(typeof(DeviceType)).Where(e => e != DeviceType.Other.ToString()))
                {
                    ComboBox_Device.Items.Add(typeName);
                }
                ComboBox_Device.SelectedIndex = 0;
            }
            void updateStatusBar()
            {
                StatusBar_ToolTip.Text = "";
                StatusBar_LastUpdate.Text = "";
                StatusBar_Version.Text = "v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;

                Label_KaPerNaujus.Text = "        ";
            }
        }

        #region MAIN MENU

        private void MenuItem_Exit_Click(object sender, EventArgs e) => Close();
        private void MenuItem_ReadFiles_Click(object sender, EventArgs e) { } // RunAsync(() => { new MyViewerForm(null).Show(); }); // TODO: implement this form
        private void MainMenu_Settings_Click(object sender, EventArgs e) => new SettingsForm(_dataCollector.IsRunning).ShowDialog();

        #endregion

        #region DEVICE LIST

        private void GridMenu_Opening(object sender, CancelEventArgs e) => UpdateDataGridContextMenu();
        private void GridMenu_Watch_Click(object sender, EventArgs e) => WatchSelectedDevices();
        private void GridMenu_Live_Click(object sender, EventArgs e) => LiveWatchSelectedDevices();
        private void GridMenu_Remove_Click(object sender, EventArgs e) => RemoveSelectedDevices();
        private void GridMenu_Connect_Click(object sender, EventArgs e) => ConnectToSelectedDevices();
        private void GridMenu_Disconnect_Click(object sender, EventArgs e) => DisconnectFromSelectedDevices();
        private void GridMenu_Configure_Click(object sender, EventArgs e) => ConfigureSelectedDevices();

        private void DataGrid_Devices_MouseClick(object sender, MouseEventArgs e) => DataGrid_Devices_MouseClick(e);
        private void DataGrid_Devices_DoubleClick(object sender, EventArgs e) => DataGrid_Devices.BeginEdit(true);
        private void DataGrid_Devices_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) => EnterCellEdit(e);
        private void DataGrid_Devices_CellValueChanged(object sender, DataGridViewCellEventArgs e) => TryEndCellEdit();

        private void TextBox_AddDeviceKeyDown(object sender, KeyEventArgs e) => AddDevice_OnEnter(sender, e);
        private void TextBox_AddDevice_TextChanged(object sender, EventArgs e) => UpdateAddDeviceComponents(false);
        private void TextBox_Description_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' || e.KeyChar == '\n')
            {
                e.Handled = true;
            }
        }

        private void Button_AddDevice_Click(object sender, EventArgs e) => AddDevice();

        private void ComboBox_Device_SelectedIndexChanged(object sender, EventArgs e) { }

        #endregion

        #region OTHER

        private void UpdateDataCollectorButton()
        {
            Button_StartCollector.Enabled = 
                Devices.Where(d => d.ConnectionState == ConnectionState.Connected).Any() 
                || (_dataCollector?.IsRunning ?? false);
        }

        private void Button_StartCollector_Click(object sender, EventArgs e) => TurnDataCollector();
        private void Button_OpenOutputDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(Settings.Default.OutputDirectory);
        }

        private void Button_OpenLaunchDirectory_Click(object sender, EventArgs e)
        {
            Process.Start(new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName);
        }

        private void TextBox_Log_TextChanged(object sender, EventArgs e)
        {
            TextBox_Log.SelectionStart = TextBox_Log.Text.Length;
            TextBox_Log.ScrollToCaret();
        }

        private void Button_ToggleLog_Click(object sender, EventArgs e)
        {
            ToggleLog();
            RefreshToggleLogStatus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;
            _dataCollector.Stop();
            _guiListener.Stop();
            foreach (int id in DeviceManager.Listeners.Keys)
            {
                DeviceManager.RemoveListener(id);
            }
            Application.DoEvents();
        }

        #endregion

        #region STATUS BAR

        private void UpdateStatusBar(string text) => StatusBar_ToolTip.Text = text;
        private void ClearStatusBar(object sender, EventArgs e) => UpdateStatusBar(null);

        private void Button_OpenLaunchDirectory_MouseEnter(object sender, EventArgs e) => UpdateStatusBar(new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName);
        private void Button_OpenOutputDirectory_MouseEnter(object sender, EventArgs e) => UpdateStatusBar(Settings.Default.OutputDirectory);
        private void Button_ToggleLog_MouseEnter(object sender, EventArgs e) => RefreshToggleLogStatus();
        private void Label_KaPerNaujus_MouseEnter(object sender, EventArgs e) => UpdateStatusBar("Ka per naujus?");
        private void ComboBox_Device_MouseEnter(object sender, EventArgs e) => UpdateStatusBar("Device type.");
        private void TextBox_Port_MouseEnter(object sender, EventArgs e) => UpdateStatusBar(_availablePortsTooltip);

        private void RefreshToggleLogStatus() => UpdateStatusBar(TextBox_Log.Visible ? "Hide log" : "Show log");
        private string _availablePortsTooltip = null;

        private void StatusBar_Help_Click(object sender, EventArgs e) => Process.Start("changelog.txt");

        #endregion
    }
}
