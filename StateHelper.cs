using System;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HotelBot
{
    public static class StateHelper
    {
        
        public static async void SetUserLanguageCode(Activity activity, string languageCode)
        {
            try
            {
                StateClient stateClient = activity.GetStateClient();
                BotData userData = stateClient.BotState.GetUserData(activity.ChannelId, activity.From.Id);

                userData.SetProperty<string>("LanguageCode", languageCode);
                await stateClient.BotState.SetUserDataAsync(activity.ChannelId, activity.From.Id, userData);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void SetUserLanguageCode(IDialogContext context, string languageCode)
        {
            try
            {
                context.UserData.SetValue("LanguageCode", languageCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string GetUserLanguageCode(Activity activity)
        {
            try
            {
                StateClient stateClient = activity.GetStateClient();
                BotData userData = stateClient.BotState.GetUserData(activity.ChannelId, activity.From.Id);

                var languageCode = userData.GetProperty<string>("LanguageCode");
                
                return languageCode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string GetUserLanguageCode(IDialogContext context)
        {
            try
            {
                string result;
                context.UserData.TryGetValue("LanguageCode", out result);
               
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }




    }
}