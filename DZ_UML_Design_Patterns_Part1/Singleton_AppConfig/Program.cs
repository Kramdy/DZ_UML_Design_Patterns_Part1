using System;
using System.Collections.Generic;

namespace SingletonAppConfig
{
    internal class AppConfig
    {
        private static readonly AppConfig instance = new AppConfig();
        private Dictionary<string, string> settings = new Dictionary<string, string>();
        private AppConfig() { }
        public static AppConfig Instance { get { return instance; } }
        public void SetSetting(string key, string value) { settings[key] = value; }
        public string GetSetting(string key) { return settings.ContainsKey(key) ? settings[key] : "Настройка не найдена"; }
    }
    internal class Program
    {
        private static void Main()
        {
            // Задание 1. Создайте AppConfig с паттерном Singleton для глобальных
            // настроек. Храните Dictionary<string, string>. Реализуйте SetSetting
            // и GetSetting. Все операции выполняйте через единственный экземпляр.
            AppConfig config = AppConfig.Instance;
            config.SetSetting("Theme", "Dark");
            config.SetSetting("Language", "English");
            Console.WriteLine("Theme: " + config.GetSetting("Theme"));
            Console.WriteLine("Language: " + config.GetSetting("Language"));
            Console.WriteLine("Это один экземпляр: " + (config == AppConfig.Instance));
            Console.ReadKey();
        }
    }
}
