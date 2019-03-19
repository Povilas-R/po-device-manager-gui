using Po.Devices.Generic;
using System;
using static Po.Forms.Threading.ThreadService;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        private event EventHandler<MessageCallEventArgs> MessageCallHandler;
        private event EventHandler<ConnectionChangedEventArgs> ConnectionChangedHandler;
        private event EventHandler<DataReceivedEventArgs> DataReceivedHandler;

        private void InitializeEvents()
        {
            MessageCallHandler += new EventHandler<MessageCallEventArgs>((o, e) => InvokeInfoMessage(e.Message));
            ConnectionChangedHandler += new EventHandler<ConnectionChangedEventArgs>((o, e) => InvokeDeviceGridUpdate());
            DataReceivedHandler += new EventHandler<DataReceivedEventArgs>((o, e) =>
            {
                try
                {
                    if (LiveListeners.ContainsKey(e.Device.ID))
                    {
                        LiveListeners[e.Device.ID].UpdateInfo(e.LivePreviewInfo);
                    }
                }
                catch { }
            });
        }
    }
}
