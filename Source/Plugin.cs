using System;
using System.IO;
using System.Windows;
using Orcus.Administration.Plugins;

namespace BuildPumper
{
    public class Plugin : IBuildPlugin
    {
        private readonly Settings _settings;

        public Plugin()
        {
            _settings = new Settings();
        }

        public bool SettingsAvailable { get; } = true;
        public BuildType BuildType { get; } = BuildType.ChangeFile;

        public bool DoWork(ref string path, IBuildLogger buildLogger)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Write))
            {
                long bytesToAdd;
                var size = _settings.Size*(_settings.SizeIsMiB ? (long) Math.Pow(1024, 2) : 1024);
                if (_settings.IsFinalSize)
                    bytesToAdd = size - fs.Length;
                else
                    bytesToAdd = size;

                if (bytesToAdd < 0)
                {
                    buildLogger.Error("Can't reduce the size of the file");
                    return false;
                }

                buildLogger.Status($"Pumping {bytesToAdd} bytes into the file");

                for (int i = 0; i < bytesToAdd; i++)
                    fs.WriteByte(0);

                buildLogger.Status("Pumping successful");
            }

            return true;
        }

        public void OpenSettings(Window ownerWindow)
        {
            var window = new SettingsWindow(_settings) {Owner = ownerWindow};
            window.ShowDialog();
        }
    }
}