using System;

namespace TestConsoleApplication.Configuration
{
    [Serializable]
    public class AppConfig
    {
        public AppConfig()
        {
            Width = 200;
            Height = 200;
        }

        public double Width { get; set; }
        public double Height { get; set; }
    }
}