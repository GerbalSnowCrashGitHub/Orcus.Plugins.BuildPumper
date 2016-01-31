namespace BuildPumper
{
    public class Settings
    {
        public long Size { get; set; } = 0;
        public bool SizeIsMiB { get; set; } = true;
        public bool IsFinalSize { get; set; } = true;
    }
}