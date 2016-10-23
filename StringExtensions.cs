using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBot.Translator;
using HotelBot.Utilities;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HotelBot
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