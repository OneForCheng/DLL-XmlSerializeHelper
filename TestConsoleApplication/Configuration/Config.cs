using System;
using ForCheng.XmlSerialize;


namespace TestConsoleApplication.Configuration
{
    [Serializable]
    public class Config : XmlSerializeHelper<Config>
    {
        public Config()
        {
            UserConfig = new UserConfig();
            AppConfig  = new AppConfig();
        }

        public UserConfig UserConfig { get; set; }

        public AppConfig AppConfig { get; set; }

        protected override void LoadCore(Config obj)
        {
            UserConfig = obj.UserConfig;
            AppConfig = obj.AppConfig;
        }
    }
}