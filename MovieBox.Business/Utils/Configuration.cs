using System.Configuration;

namespace MovieBox.Business.Utils
{
    public static class Configuration
    {
        public static string AppSettings(string code)
        {
            return ConfigurationManager.AppSettings[code];
        }
    }
}
