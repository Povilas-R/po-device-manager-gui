using Po.Forms.Threading;
using System;
using System.Windows.Forms;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        private ThreadService _guiListener;
        private void InitializeGuiListener()
        {
            _guiListener = new ThreadService("gui-listener")
            {
                StartDelay = 1000
            };
            _guiListener.MessageCall += MessageCallHandler;
            _guiListener.Update += new EventHandler<ThreadService>((o, e) => BeginInvoke((MethodInvoker)delegate { UpdateLogStatusHistory(null); }));
        }
    }
}
