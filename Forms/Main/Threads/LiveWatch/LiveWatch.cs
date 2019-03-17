using Po.Devices;
using Po.Forms.Threading;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		public Dictionary<int, LiveWatchListener> LiveListeners = new Dictionary<int, LiveWatchListener>();

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

			LiveListeners.Add(id, new LiveWatchListener(device));
			LiveListeners[id].MessageCall += MessageCallHandler;
			LiveListeners[id].ThreadCompleted += new EventHandler<ThreadService>((o, e) => LiveListeners.Remove(((LiveWatchListener)e).Device.ID));
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

		public partial class LiveWatchListener : ThreadService, IDisposable
		{
			public readonly Device Device;
			public LiveWatchForm Form;

			public LiveWatchListener(Device device) : base(device.DeviceName + "_LiveWatch")
			{
				Device = device;
				Form = new LiveWatchForm(Device);
			}

			protected override void Loop() => Form.ShowDialog();
			public new long UpdateInterval => Form.UpdateIntervalMillis;

			public void Dispose()
			{
				if (Form != null)
				{
					Form.Dispose();
				}
				GC.SuppressFinalize(this);
			}

			public void InvokeUpdate(params string[] infoBlocks)
			{
				try
				{
					Form.InvokeUpdateLiveInfo(infoBlocks);
				}
				catch { }
			}

		}
	}
}
