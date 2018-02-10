using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using HotelBot.Translator;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using HotelBot.Extensions;
using HotelBot.Models;
using HotelBot.Utilities;

namespace HotelBot.Controllers
{
   [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            //trust Webchat & SMS channel
            MicrosoftAppCredentials.TrustServiceUrl(@"https://webchat.botframework.com", DateTime.MaxValue);
            MicrosoftAppCredentials.TrustServiceUrl(@"https://sms.botframework.com", DateTime.MaxValue);

            Trace.TraceInformation($"Incoming Activity is {activity.ToJson()}");
            if (activity.Type == ActivityTypes.Message)
            {
                if (!string.IsNullOrEmpty(activity.Text))
                {
                    //detect language of input text
                    var userLanguage = TranslationHandler.DetectLanguage(activity);

                    //save user's LanguageCode to Azure Table Storage
                    var message = activity as IMessageActivity;

                    try
                    {
                        using(var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                    {
                            var botDataStore = scope.Resolve<IBotDataStore<BotData>>();
                            var key = new AddressKey()
                            {
                                BotId = message.Recipient.Id,
                                ChannelId = message.ChannelId,
                                UserId = message.From.Id,
                                ConversationId = message.Conversation.Id,
                                ServiceUrl = message.ServiceUrl
                            };

                            var userData = await botDataStore.LoadAsync(key, BotStoreType.BotUserData, CancellationToken.None);

                            var storedLanguageCode = userData.GetProperty<string>(StringConstants.UserLanguageKey);

                            //update user's language in Azure Table Storage
                            if (storedLanguageCode != userLanguage)
                            {
                                userData.SetProperty(StringConstants.UserLanguageKey, userLanguage);
                                await botDataStore.SaveAsync(key, BotStoreType.BotUserData, userData, CancellationToken.None);
                                await botDataStore.FlushAsync(key, CancellationToken.None);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                    //translate activity.Text to English before sending to LUIS for intent
                    activity.Text = TranslationHandler.TranslateTextToDefaultLanguage(activity, userLanguage);
                    
                    await Conversation.SendAsync(activity, MakeRoot);
                }
                
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        internal static IDialog<object> MakeRoot()
        {
            try
            {
                return Chain.From(() => new ChatDialog());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private async Task<Activity> HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {

                IConversationUpdateActivity conversationupdate = message;

                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, message))
                {
                    var client = scope.Resolve<IConnectorClient>();
                    if (conversationupdate.MembersAdded.Any())
                    {
                        var reply = message.CreateReply();
                        foreach (var newMember in conversationupdate.MembersAdded)
                        {
                             if (newMember.Id == message.Recipient.Id)
                            {
                                reply.Text = ChatResponse.Greeting;

                                await client.Conversations.ReplyToActivityAsync(reply);
                            }
                        }
                    }
                }
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}