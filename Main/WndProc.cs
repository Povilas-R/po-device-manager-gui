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
                case WndMessages.DeviceChange:
                    UpdateAvailablePorts(SerialPort.GetPortNames());
                    break;
            }
            base.WndProc(ref m);
        }

        private struct WndMessages
        {
            public const int
                DeviceChange = 0x0219;
        }
    }
}
