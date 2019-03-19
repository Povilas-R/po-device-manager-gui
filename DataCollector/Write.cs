using Po.Devices;
using DeviceManagerGUI.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeviceManagerGUI.DataCollecting
{
    public partial class DataCollector
    {
        public void WriteSeparate()
        {
            foreach (var listener in _deviceManager.Listeners.Values.Where(e => e.Device.ConnectionState == ConnectionState.Connected))
            {
                string port = listener.Device.ComPort;
                string filePath = Path.Combine(Settings.Default.OutputDirectory, listener.Device.FileName);

                string lines = listener.GetDataLines();
                _streamWriters[port].Write(lines);
                _streamWriters[port].Flush();
                _streamWriters[port].Close();
                _streamWriters[port] = new StreamWriter(new FileStream(
                    filePath, FileMode.Append, FileAccess.Write, FileShare.Read));
            }
        }

        private Dictionary<string, StreamWriter> _streamWriters = new Dictionary<string, StreamWriter>();
        public bool PrepareFileStreams()
        {
            CloseFileStreams();
            try
            {
                foreach (var device in _deviceManager.Devices)
                {
                    string filePath = Path.Combine(Settings.Default.OutputDirectory, device.FileName);
                    if (File.Exists(filePath))
                    {
                        _streamWriters.Add(device.ComPort, new StreamWriter(new FileStream(
                            filePath, FileMode.Append, FileAccess.Write, FileShare.Read)));
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                OnMessageCall($"Exception data collector thread when preparing file streams: {ex.Message}");
                return false;
            }
        }
        public void CloseFileStreams()
        {
            foreach (var stream in _streamWriters.Values)
            {
                stream.Close();
                stream.Dispose();
            }
            _streamWriters.Clear();
        }

        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            foreach (var stream in _streamWriters.Values)
            {
                stream.Close();
                stream.Dispose();
            }
            _streamWriters.Clear();

            _disposed = true;
            base.Dispose(disposing);
        }
    }
}
