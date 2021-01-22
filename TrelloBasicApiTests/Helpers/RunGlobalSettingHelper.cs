using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TrelloBasicApiTests.Helpers
{
    public class RunGlobalSettingHelper
    {
        private static readonly IConfigurationRoot RunSettings;

        static RunGlobalSettingHelper()
        {
            RunSettings = ReadConfiguration();
        }

        public static IConfigurationSection WebDriverSettings => RunSettings.GetSection("webdriver");
        public static IConfigurationSection RunEnvironment => RunSettings.GetSection("environment");
        public static IConfigurationSection UiSettings => RunSettings.GetSection("ui");

        private static IConfigurationRoot ReadConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("settingsGlobal.json", optional: false, reloadOnChange: true);
            return configurationBuilder.Build();
        }
    }
}
