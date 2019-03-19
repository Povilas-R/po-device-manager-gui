using Po.Devices;
using Po.Forms.Logging;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using static Po.Utilities.Helper;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        private void AddDevice_OnEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                var fields = GetAddDeviceFields();

                if (!CheckDeviceName(fields.DeviceName))
                {
                    TextBox_DeviceName.Focus();
                    TextBox_DeviceName.SelectAll();
                }
                else if (sender == TextBox_DeviceName || !CheckPort(fields.Port))
                {
                    TextBox_Port.Focus();
                    TextBox_Port.SelectAll();
                }
                else if (sender == TextBox_Port || !CheckDescription(fields.Description))
                {
                    TextBox_Description.Focus();
                    TextBox_Description.SelectAll();
                }
                else if (sender == TextBox_Description || !CheckFileName(fields.FileName))
                {
                    TextBox_FileName.Focus();
                    TextBox_FileName.SelectAll();
                }
                else if (sender == TextBox_FileName)
                {
                    AddDevice();
                }
            }
        }
        private void UpdateAddDeviceComponents(bool showErrorText)
        {
            var fields = GetAddDeviceFields();

            if (!CheckDeviceName(fields.DeviceName, showErrorText))
            {
                TextBox_Port.ReadOnly = true;
                TextBox_FileName.ReadOnly = true;
                Button_AddDevice.Enabled = false;
                if (showErrorText)
                {
                    TextBox_DeviceName.Focus();
                    TextBox_DeviceName.SelectAll();
                }
            }
            else if (!CheckPort(fields.Port, showErrorText))
            {
                TextBox_Port.ReadOnly = false;
                TextBox_FileName.ReadOnly = true;
                Button_AddDevice.Enabled = false;
                if (showErrorText)
                {
                    TextBox_Description.Focus();
                    TextBox_Description.SelectAll();
                }
            }
            else if (!CheckDescription(fields.Description, showErrorText))
            {
                Button_AddDevice.Enabled = false;
                if (showErrorText)
                {
                    TextBox_Port.Focus();
                    TextBox_Port.SelectAll();
                }
            }
            else if (!CheckFileName(fields.FileName, showErrorText))
            {
                TextBox_Port.ReadOnly = false;
                TextBox_FileName.ReadOnly = false;
                Button_AddDevice.Enabled = false;
                if (showErrorText)
                {
                    TextBox_FileName.Focus();
                    TextBox_FileName.SelectAll();
                }
            }
            else
            {
                TextBox_Port.ReadOnly = false;
                TextBox_FileName.ReadOnly = false;
                Button_AddDevice.Enabled = true;
            }
        }

        private void AddDevice()
        {
            // Checks and corrects port string
            var fields = GetAddDeviceFields();

            if (!CheckPort(fields.Port))
            {
                TextBox_Port.Focus();
                TextBox_Port.SelectAll();
                return;
            }
            if (!CheckDeviceName(fields.DeviceName))
            {
                TextBox_DeviceName.Focus();
                TextBox_DeviceName.SelectAll();
                return;
            }
            if (!CheckDescription(fields.Description))
            {
                TextBox_Description.Focus();
                TextBox_Description.SelectAll();
                return;
            }
            if (!CheckFileName(fields.FileName))
            {
                TextBox_FileName.Focus();
                TextBox_FileName.SelectAll();
                return;
            }

            var type = (DeviceType)ComboBox_Device.SelectedIndex;
            Devices.Add(
                fields.DeviceName,
                type,
                fields.Port,
                fields.Description,
                fields.FileName,
                0);

            RefreshDeviceGridRows();
            UpdateAvailablePortsTooltip(SerialPort.GetPortNames());

            TextBox_DeviceName.Clear();
            TextBox_Port.Clear();
            TextBox_Description.Clear();
            TextBox_FileName.Clear();
            TextBox_DeviceName.Focus();
        }

        private (string DeviceName, string Port, string Description, string FileName) GetAddDeviceFields()
        {
            string name = TextBox_DeviceName.Text.GetDeviceName();
            string port = TextBox_Port.Text.GetPort();
            string fileName = TextBox_FileName.Text.GetFileName("csv", "txt");
            string description = TextBox_Description.Text;

            return (name, port, description, fileName);
        }
        private bool CheckDeviceName(string name, bool showError = true, string oldName = null)
        {
            string errorText = null;
            if (string.IsNullOrEmpty(name))
            {
                errorText = "Invalid name.";
            }
            else if (Devices.Where(a => a.DeviceName == name && a.DeviceName != oldName).Count() > 0)
            {
                errorText = "Device name already used.";
            }
            else
            {
                return true;
            }

            if (showError)
            {
                Logger.ShowMessage(errorText);
            }
            return false;
        }
        private bool CheckPort(string port, bool showError = true, string oldPort = null)
        {
            string errorText = null;
            if (string.IsNullOrEmpty(port))
            {
                errorText = "Invalid communication port.";
            }
            else if (Devices.Where(a => a.ComPort == port && a.ComPort != oldPort).Count() > 0)
            {
                errorText = "Communication port already used.";
            }
            else
            {
                return true;
            }

            if (showError)
            {
                Logger.ShowMessage(errorText);
            }
            return false;
        }
        private bool CheckDescription(string description, bool showError = true)
        {
            string errorText = null;
            if (string.IsNullOrEmpty(description))
            {
                return true;
            }
            else if (description.Contains('\r') || description.Contains('\n'))
            {
                errorText = "Description may not contain new lines.";
            }
            else
            {
                return true;
            }

            if (showError)
            {
                Logger.ShowMessage(errorText);
            }
            return false;
        }
        private bool CheckFileName(string fileName, bool showError = true, string oldFileName = null)
        {
            fileName = fileName?.ToLower();
            oldFileName = oldFileName?.ToLower();

            string errorText = null;
            if (string.IsNullOrEmpty(fileName))
            {
                errorText = "File name cannot be empty.";
            }
            else if (Devices.Where(e => e.FileName.ToLower() == fileName && e.FileName.ToLower() != oldFileName).Count() > 0)
            {
                errorText = "File name already used.";
            }
            else if (!IsFileNameValid(fileName))
            {
                errorText = "Invalid file name.";
            }
            else
            {
                return true;
            }

            if (showError)
            {
                Logger.ShowMessage(errorText);
            }
            return false;
        }
    }
}
