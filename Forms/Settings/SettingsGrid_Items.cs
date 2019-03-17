using Po.Forms.PropertyGrid;
using DeviceManagerGUI.Properties;
using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Windows.Forms.Design;
using Po.Utilities;
using static Po.Utilities.Helper;

namespace DeviceManagerGUI
{
	public partial class SettingsGridObject
	{
		private enum Position : ushort
		{
			Misc,
			DataViewer, // TODO: add viewer form
			DataCollector
		}

		#region DATA COLLECTOR

		private long _writeIntervalMillis;
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Time interval in milliseconds for writing all device data to files when data collector is on.")]
		[SortedCategory("Data collector", (ushort)Position.DataCollector)]
		[DisplayName("Write interval")]
		public long WriteIntervalMillis
		{
			get => _writeIntervalMillis;
			set
			{
				if (value < Settings.Default.WriteIntervalMillisMin)
				{
					throw new Exception($"Write interval cannot be lower than {Settings.Default.WriteIntervalMillisMin}ms.");
				}
				_writeIntervalMillis = value;
			}
		}

		private string _outputDirectoryPath;
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Output directory path where all the collected device data will be written to.")]
		[SortedCategory("Data collector", (ushort)Position.DataCollector)]
		[DisplayName("Output directory path")]
		[Editor(typeof(FolderNameEditor), typeof(UITypeEditor))]
		public string OutputDirectory
		{
			get => _outputDirectoryPath;
			set
			{
				value = value.Trim();
				if (!IsDirectoryPathValid(value))
				{
					if (string.IsNullOrEmpty(value))
					{
						value = new DirectoryInfo(Assembly.GetEntryAssembly().Location).Parent.FullName;
					}
					else
					{
						throw new Exception("Invalid output directory path.");
					}
				}

				_outputDirectoryPath = value;
			}
		}

		#endregion

		#region DATA VIEWER

		private long _dataViewerUpdateInterval;
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Default automatic update interval for data viewer in milliseconds.")]
		[SortedCategory("Data viewer", (ushort)Position.DataViewer)]
		[DisplayName("Default update interval")]
		public long DataViewerUpdateInterval
		{
			get => _dataViewerUpdateInterval;
			set
			{
				if (value < Settings.Default.DataViewerUpdateIntervalMillisMin)
				{
					throw new Exception($"Update interval cannot be lower than {Settings.Default.DataViewerUpdateIntervalMillisMin}ms.");
				}
				_dataViewerUpdateInterval = value;
			}
		}

		#endregion

		#region MISC

		private string _logFileName;
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Log file name where the application will save its log to. Date string in \"[yyyy-mm-dd] \" format is always appended to the start of the log file name.")]
		[SortedCategory("Misc", (ushort)Position.Misc)]
		[DisplayName("Log file name")]
		public string LogFileName
		{
			get => _logFileName;
			set
			{
				value = value.Trim();
				if (value.Length > 0 && (value.Length < 5 || value.Substring(value.Length - 4) != ".txt"))
				{
					value += ".txt";
				}
				if (!IsFileNameValid(value))
				{
					throw new Exception("Invalid log file name.");
				}

				_logFileName = value;
			}
		}

		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Hide log box on startup.")]
		[SortedCategory("Misc", (ushort)Position.Misc)]
		[DisplayName("Hide log on startup")]
		public bool HideLogOnStartup { get; set; }
		
		[Browsable(true)]
		[ReadOnly(false)]
		[Description("Last update information in status bar linger time in seconds.")]
		[SortedCategory("Misc", (ushort)Position.Misc)]
		[DisplayName("Last update linger time")]
		public int LastUpdateLinger { get; set; }

		#endregion
	}

}
