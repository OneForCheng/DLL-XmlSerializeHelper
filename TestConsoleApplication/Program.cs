using System;
using System.Configuration;
using TestConsoleApplication.Configuration;

namespace TestConsoleApplication
{
    class Program
    {

        static void SaveAsDemo()
        {
            var config = new Config
            {
                AppConfig =
                {
                    Width = 50,
                    Height = 100
                },
                UserConfig =
                {
                    Maximized = true
                }
            };
            //保存配置信息（将对象的属性值序列化到文件中）
            config.SaveAs(ConfigurationManager.AppSettings["ConfigPath"]);

        }

        static void LoadAndSaveDemo()
        {
            var config = new Config();
            config.Load(ConfigurationManager.AppSettings["ConfigPath"]);

            Console.WriteLine("XmlFilePath: {0}", config.XmlFilePath);
            Console.WriteLine("Height: {0}",config.AppConfig.Height);
            Console.WriteLine("Width: {0}", config.AppConfig.Width);
            Console.WriteLine("Maximized: {0}", config.UserConfig.Maximized);
            Console.WriteLine("AutoRun: {0}", config.UserConfig.AutoRun);
           
            config.AppConfig.Width = 0;//修改信息

            //文件路径为：config.XmlFilePath
            config.Save();//保存配置信息，序列化保存到文件中
        }

        static void Main(string[] args)
        {
            //另存为演示
            SaveAsDemo();

            //加载与保存演示
            LoadAndSaveDemo();

            Console.ReadKey();
        }
    }
}
