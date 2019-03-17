using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 537: //WM_DEVICECHANGE
					UpdateAvailablePorts(SerialPort.GetPortNames());
					break;
			}
			base.WndProc(ref m);
		}
	}
}
