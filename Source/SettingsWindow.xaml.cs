using System;
using Sorzus.Wpf.Toolkit;

namespace BuildPumper
{
    /// <summary>
    ///     Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        internal SettingsWindow(Settings settings)
        {
            Settings = settings;
            InitializeComponent();
            SourceInitialized += OnSourceInitialized;
        }

        public Settings Settings { get; }

        private void OnSourceInitialized(object sender, EventArgs eventArgs)
        {
            this.RemoveIcon();
        }
    }
}