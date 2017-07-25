using HotelBot.Translator;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HotelBot.Utilities
{
    public static class StringExtensions
    {
        public static string ToUserLocale(this string text, IDialogContext context)
        {
            var userLanguageCode = StateHelper.GetUserLanguageCode(context);
                if (userLanguageCode != "en")
                {
                    text = TranslationHandler.DoTranslation(text, "en", userLanguageCode);
                }

            return text;
        }
        public static string ToUserLocale(this string text, Activity activity)
        {
           var userLanguageCode = StateHelper.GetUserLanguageCode(activity);
                if (userLanguageCode != "en")
                {
                    text = TranslationHandler.DoTranslation(text, "en", userLanguageCode);
                }

            return text;
        }
    }
}