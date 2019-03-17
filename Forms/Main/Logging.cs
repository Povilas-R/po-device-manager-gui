using Po.Forms.Logging;
using DeviceManagerGUI.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace DeviceManagerGUI
{
	public partial class MainForm
	{
		private void ToggleLog()
		{
			if (TextBox_Log.Visible)
			{
				HideLog();
			}
			else
			{
				ShowLog();
			}
		}

		private void HideLog(bool bypassCheck = false)
		{
			if (TextBox_Log.Visible || bypassCheck)
			{
				Size = new Size(Size.Width - 423, Size.Height);
				Button_ToggleLog.Text = ">>";
				TextBox_Log.Visible = false;
			}
		}
		private void ShowLog()
		{
			if (!TextBox_Log.Visible)
			{
				Size = new Size(Size.Width + 423, Size.Height);
				Button_ToggleLog.Text = "<<";
				TextBox_Log.Visible = true;
			}
		}
		
		public void InvokeInfoMessage(string info)
		{
			try
			{
				if (IsHandleCreated)
				{
					if (!_isFormClosing)
					{
						Invoke((MethodInvoker)delegate
						{
							AppendLog(info);
						});
					}
				}
				else
				{
					AppendLog(info);
				}
			}
			catch { }
		}

		private void AppendLog(string info)
		{
			Logger.Log(info);
			UpdateLogStatusHistory(info);
		}

		private Stopwatch _lastUpdateWatch = new Stopwatch();
		public void UpdateLogStatusHistory(string info)
		{
			if (string.IsNullOrEmpty(info))
			{
				if (_lastUpdateWatch.ElapsedMilliseconds > Settings.Default.LastUpdateLingerSeconds * 1000)
				{
					_lastUpdateWatch.Reset();
					StatusBar_LastUpdate.Text = null;
				}

				return;
			}
			_lastUpdateWatch.Restart();
			StatusBar_LastUpdate.Text = info.Split(':')[0].TrimEnd('.');
		}
	}
}
