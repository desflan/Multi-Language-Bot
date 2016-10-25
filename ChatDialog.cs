using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace HotelBot
{
    [Serializable]
    [LuisModel("744941fe-cabc-493b-9ee1-c2da9e8d5357", "4bc6e20c7a284c2b8b8e0d4afe22e24b")]
    public class ChatDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Default;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }

        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Greeting;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }

        [LuisIntent("Farewell")]
        public async Task Farewell(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Farewell;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }

        [LuisIntent("SwimmingPool")]
        public async Task SwimmingPool(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.SwimmingPool;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }

        [LuisIntent("Location")]
        public async Task Location(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Location;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }

        [LuisIntent("Restaurant")]
        public async Task Restaurant(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Restaurant;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }


        [LuisIntent("Wifi")]
        public async Task Wifi(IDialogContext context, LuisResult result)
        {
            var response = ChatResponse.Wifi;

            await context.PostAsync(response.ToUserLocale(context));

            context.Wait(MessageReceived);
        }
    }

    
}