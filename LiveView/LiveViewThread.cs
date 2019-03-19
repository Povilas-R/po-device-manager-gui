using Po.Devices;
using Po.Forms;
using Po.Forms.Threading;

namespace DeviceManagerGUI.LiveView
{
    public partial class LiveViewThread : ThreadService
    {
        public readonly Device Device;
        private LiveViewForm _form;

        public LiveViewThread(Device device) : base(device.DeviceName + "-live-view")
        {
            Device = device;
            _form = new LiveViewForm(Device);
        }

        protected override void Loop() => _form.ShowDialog();
        public new long UpdateInterval => _form.MinUpdateInterval;

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            _form?.Dispose();

            _disposed = true;
            base.Dispose(disposing);
        }

        public void UpdateInfo(params string[] infoBlocks)
        {
            _form.UpdateInfo(infoBlocks);
        }
        public void FocusWindow()
        {
            _form.FocusWindow();
        }
    }
}
