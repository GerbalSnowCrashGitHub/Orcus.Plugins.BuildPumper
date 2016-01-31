namespace BuildPumper
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow
    {
        internal SettingsWindow(Settings settings)
        {
            Settings = settings;
            InitializeComponent();
        }

        public Settings Settings { get; }
    }
}