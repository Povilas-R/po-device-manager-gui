using DeviceManagerGUI.LiveView;
using Po.Forms.Threading;
using System;
using System.Collections.Generic;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        public Dictionary<int, LiveViewThread> LiveListeners = new Dictionary<int, LiveViewThread>();

        private void StartLiveWatchListener(int id)
        {
            var device = Devices.GetDevice(id);
            if (device == null)
            {
                return;
            }

            if (LiveListeners.ContainsKey(id) && LiveListeners[id].IsRunning)
            {
                throw new Exception("Unable to trigger listener. The listener thread is already running.");
            }

            LiveListeners.Add(id, new LiveViewThread(device));
            LiveListeners[id].MessageCall += MessageCallHandler;
            LiveListeners[id].ThreadCompleted += new EventHandler<ThreadService>((o, e) => LiveListeners.Remove(((LiveViewThread)e).Device.ID));
            LiveListeners[id].Start();
        }
        private void StopLiveWatchListener(int id)
        {
            if (LiveListeners.ContainsKey(id) && LiveListeners[id].IsRunning)
            {
                LiveListeners[id].Stop();
            }
            else
            {
                LiveListeners.Remove(id);
            }
        }
    }
}
