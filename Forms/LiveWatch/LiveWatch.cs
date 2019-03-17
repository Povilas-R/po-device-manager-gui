using Po.Devices;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DeviceManagerGUI
{
	public partial class LiveWatchForm : Form
	{
		public LiveWatchForm(Device device)
		{
			InitializeComponent();
			Text = $"\"{device.DeviceName}\" ({device.DeviceType.ToString()} device) on {device.ComPort}";
			Label_Info1.Text = "";
			Label_Info2.Text = "";
			Height = 100;
			Width = 400;
		}

		private Stopwatch _updateWatch = new Stopwatch();
		public long UpdateIntervalMillis = 100;
		public void InvokeUpdateLiveInfo(params string[] infoBlocks)
		{
			BeginInvoke((MethodInvoker)delegate
			{
				string[] panels = infoBlocks;

				if (_updateWatch.IsRunning && _updateWatch.ElapsedMilliseconds < UpdateIntervalMillis)
				{
					return;
				}
				_updateWatch.Restart();

				int height = 0;
				int width = 0;
				foreach (string info in panels)
				{
					int tempWidth = 0;
					string[] lines = info.Split('\n');
					foreach (string line in lines)
					{
						tempWidth = Math.Max(tempWidth, line.TrimEnd(' ', '\r').Length);
					}
					width = tempWidth;
					height = Math.Max(height, lines.Length);
				}

				height *= Label_Info1.Font.Height;
				height += 70;
				width = (int)(width * Label_Info1.Font.Size);

				if (panels.Length < 2)
				{
					Panel_Info2.Visible = false;
					width += 20;
				}
				else if (panels.Length >= 2)
				{
					Panel_Info2.Visible = true;
					width += Panel_Info1.Width + 20;
				}

				width = Math.Max(400, width);
				Size = new System.Drawing.Size(width, height);

				if (panels.Length > 0)
				{
					Label_Info1.Text = panels[0];
				}
				if (panels.Length > 1)
				{
					Label_Info2.Text = panels[1];
				}
			});
		}
	}
}
