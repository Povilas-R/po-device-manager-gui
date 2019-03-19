using System;
using System.Windows.Forms;

namespace DeviceManagerGUI.UserSettings
{
    public partial class SettingsForm : Form
    {
        private SettingsGridObject _settings = new SettingsGridObject();
        private bool _isCollectingData = false;

        public SettingsForm(bool isCollectingData)
        {
            _isCollectingData = isCollectingData;
            InitializeComponent();
            fillSettingsGrid();

            void fillSettingsGrid()
            {
                Grid.SelectedObject = _settings;

                foreach (Control control in Controls)
                {
                    switch (control)
                    {
                        case Button button:
                            if (button != Button_Cancel)
                            {
                                button.Enabled = !_isCollectingData;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void Button_LoadDefault_Click(object sender, EventArgs e)
        {
            _settings.LoadDefault();
            Grid.Refresh();
        }
        private void Button_Reload_Click(object sender, EventArgs e)
        {
            _settings.ReloadSettings();
            Grid.Refresh();
        }
        private void Button_Save_Click(object sender, EventArgs e) => _settings.Save();
        private void Button_OK_Click(object sender, EventArgs e) => _settings.Save();
    }
}
