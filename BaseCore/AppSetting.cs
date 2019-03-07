using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;

namespace BaseCore
{
    public class AppSetting
    {
        private static readonly object objLock = new object();
        private static AppSetting instance = null;
        private IConfigurationRoot Config { get; set; }
        private AppSetting()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Config = builder.Build();
        }
        public static AppSetting GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new AppSetting();
                    }
                }
            }
            return instance;
        }
        public static string GetConfig(int option)
        {
            string name = "";
            switch (option)
            {
                case 1:
                    name = "ConnectionStrings:TestDb";
                    break;
            }
            return GetInstance().Config.GetSection(name).Value;
        }        
    }
}
