using Po.Utilities;

namespace DeviceManagerGUI.UserSettings
{
    public partial class SettingsGridObject
    {
        public SettingsGridObject()
        {
            ReloadValues();
        }

        private Properties.Settings _settings = Properties.Settings.Default;

        public void Save()
        {
            // Data collector
            _settings.WriteIntervalMillis = WriteIntervalMillis;
            _settings.OutputDirectory = OutputDirectory;

            // Data viewer
            _settings.DataViewerUpdateIntervalMillis = DataViewerUpdateInterval;

            // Misc
            _settings.LogFileName = LogFileName;
            _settings.HideLogOnStartup = HideLogOnStartup;
            _settings.LastUpdateLingerSeconds = LastUpdateLinger;

            _settings.Save();
        }
        public void ReloadSettings()
        {
            _settings.Reload();
            ReloadValues();
        }
        public void LoadDefault()
        {
            // Data collector
            WriteIntervalMillis = _settings.Properties.GetDefault<long>("WriteIntervalMillis");
            OutputDirectory = _settings.Properties.GetDefault<string>("OutputDirectory");

            // Data viewer
            DataViewerUpdateInterval = _settings.Properties.GetDefault<long>("DataViewerUpdateIntervalMillis");

            // Misc
            LogFileName = _settings.Properties.GetDefault<string>("LogFileName");
            HideLogOnStartup = _settings.Properties.GetDefault<bool>("HideLogOnStartup");
            LastUpdateLinger = _settings.Properties.GetDefault<int>("LastUpdateLingerSeconds");
        }

        private void ReloadValues()
        {
            // Data collector
            WriteIntervalMillis = _settings.WriteIntervalMillis;
            OutputDirectory = _settings.OutputDirectory;

            // Data viewer
            DataViewerUpdateInterval = _settings.DataViewerUpdateIntervalMillis;

            // Misc
            LogFileName = _settings.LogFileName;
            HideLogOnStartup = _settings.HideLogOnStartup;
            LastUpdateLinger = _settings.LastUpdateLingerSeconds;
        }
    }
}
