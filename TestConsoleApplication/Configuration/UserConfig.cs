using System;

namespace TestConsoleApplication.Configuration
{
    [Serializable]
    public class UserConfig
    {
        public UserConfig()
        {
            AutoRun = true;
            Maximized = false;
        }

        public bool AutoRun { get; set; }

        public bool Maximized { get; set; }
    }
}