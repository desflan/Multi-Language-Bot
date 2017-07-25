using System.Configuration;

namespace HotelBot.Utilities
{
    public static class Settings
    {
        public static string GetSubscriptionKey()
        {
            return ConfigurationManager.AppSettings["SubscriptionKey"];
        }
        public static string GetCognitiveServicesTokenUri()
        {
            return ConfigurationManager.AppSettings["CognitiveServicesTokenUri"];
        }
        public static string GetTranslatorUri()
        {
            return ConfigurationManager.AppSettings["TranslatorUri"];
        }
    }
}