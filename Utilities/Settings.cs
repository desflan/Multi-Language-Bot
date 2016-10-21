using System.Configuration;

namespace HotelBot.Utilities
{
    public static class Settings
    {
        public static string GetTranslatorClientId()
        {
            return ConfigurationManager.AppSettings["TranslatorClientId"];
        }
        public static string GetTranslatorClientSecret()
        {
            return ConfigurationManager.AppSettings["TranslatorClientSecret"];
        }
        public static string GetTokenUri()
        {
            return ConfigurationManager.AppSettings["TokenUri"];
        }
        public static string GetTranslatorUri()
        {
            return ConfigurationManager.AppSettings["TranslatorUri"];
        }
    }
}