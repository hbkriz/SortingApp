using System.Configuration;

namespace SortingApp.Wrappers.ConfigurationManagerWrapper
{
    public class ConfigurationManagerWrapper : IConfigurationManagerWrapper
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}