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

        public string DoWork(string path, Action<string> logger)
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
                    throw new PluginException("Can't reduce the size of the file");

                logger.Invoke($"Pumping {bytesToAdd} bytes into the file");

                for (int i = 0; i < bytesToAdd; i++)
                    fs.WriteByte(0);

                logger.Invoke("Pumping successful");
            }

            return path;
        }

        public void OpenSettings(Window ownerWindow)
        {
            var window = new SettingsWindow(_settings) {Owner = ownerWindow};
            window.ShowDialog();
        }
    }
}