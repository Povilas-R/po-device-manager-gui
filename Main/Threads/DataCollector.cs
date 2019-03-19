using Po.Forms.Threading;
using System;
using System.Windows.Forms;
using DeviceManagerGUI.Properties;
using DeviceManagerGUI.DataCollecting;

namespace DeviceManagerGUI
{
    public partial class MainForm
    {
        private DataCollector _dataCollector;
        private void InitializeDataCollector()
        {
            _dataCollector = new DataCollector(DeviceManager)
            {
                UpdateInterval = Settings.Default.WriteIntervalMillis
            };

            _dataCollector.ThreadStarted += new EventHandler<ThreadService>((o, e) =>
            {
                InvokeInfoMessage("Data collector started.");
                BeginInvoke((MethodInvoker)delegate
                {
                    UpdateDataCollectorElements(true);
                });

                var listener = (DataCollector)e;
                listener.Refresh();

                listener.CloseFileStreams();
                if (!listener.PrepareOutputDirectory() || !listener.PrepareFileStreams())
                {
                    listener.Stop();
                }
            });
            _dataCollector.Update += new EventHandler<ThreadService>((o, e) =>
            {
                var listener = (DataCollector)e;

                listener.WriteSeparate();
            });
            _dataCollector.ThreadCompleted += new EventHandler<ThreadService>((o, e) =>
            {
                var listener = (DataCollector)e;

                listener.CloseFileStreams();
                BeginInvoke((MethodInvoker)delegate
                {
                    UpdateDataCollectorElements(false);
                });
                InvokeInfoMessage("Data collector stopped.");
            });
            _dataCollector.MessageCall += new EventHandler<ThreadService.MessageCallEventArgs>((o, e) =>
            {
                InvokeInfoMessage(e.Message);
            });
        }
        private void TurnDataCollector()
        {
            if (!_dataCollector.IsRunning)
            {
                _dataCollector.UpdateInterval = Properties.Settings.Default.WriteIntervalMillis;
                _dataCollector.Start();
            }
            else
            {
                _dataCollector.Stop();
            }

            UpdateDataCollectorButton();
        }
        private void UpdateDataCollectorElements(bool collectorStarted)
        {
            if (collectorStarted)
            {
                Button_StartCollector.Text = "Stop data collector";
            }
            else
            {
                Button_StartCollector.Text = "Start data collector";
            }

            Column_DeviceName.ReadOnly = collectorStarted;
            Column_Port.ReadOnly = collectorStarted;
            Column_Description.ReadOnly = collectorStarted;
            Column_FileName.ReadOnly = collectorStarted;
        }
    }
}
