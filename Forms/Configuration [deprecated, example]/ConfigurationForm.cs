using System;
using System.Windows.Forms;

namespace DeviceManagerGUI
{
	public partial class ConfigurationForm : Form
	{
		public ConfigurationForm()
		{
			InitializeComponent();
			Grid.SelectedObject = Configuration;
		}

		public ConfigurationGridObject Configuration = new ConfigurationGridObject();
		public uint DeviceId = 0;

		private void TextBox_ID_TextChanged(object sender, EventArgs e) => Button_Factory.Enabled = uint.TryParse(TextBox_ID.Text, out DeviceId) && DeviceId != 0;

		private void Button_Factory_Click(object sender, EventArgs e)
		{

		}

        private void Button_Configure_Click(object sender, EventArgs e)
        {

        }
    }
}
