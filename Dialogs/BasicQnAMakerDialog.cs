using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using Microsoft.Bot.Connector;
using System.Configuration;

namespace Microsoft.Bot.Sample.QnABot
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            /* Wait until the first message is received from the conversation and call MessageReceviedAsync 
            *  to process that message. */
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            /* When MessageReceivedAsync is called, it's passed an IAwaitable<IMessageActivity>. To get the message,
             *  await the result. */
            var message = await result;

            // The Utils.GetAppSetting(string key) method is for bots running on Azure 
            /* var qnaAuthKey = GetSetting("QnAAuthKey"); 
             * var qnaKBId = Utils.GetAppSetting("QnAKnowledgebaseId");
             * var endpointHostName = Utils.GetAppSetting("QnAEndpointHostName"); */

            // Run your bot application on local and access settings from your web.config file
            var qnaAuthKey = AppSettings("QnAAuthKey");
            var qnaKBId = ConfigurationManager.AppSettings["QnAKnowledgebaseId"];
            var endpointHostName = ConfigurationManager.AppSettings["QnAEndpointHostName"];

            // QnA Subscription Key and KnowledgeBase Id null verification
            if (!string.IsNullOrEmpty(qnaAuthKey) && !string.IsNullOrEmpty(qnaKBId))
            {
                // Forward to the appropriate Dialog based on whether the endpoint hostname is present
                if (string.IsNullOrEmpty(endpointHostName))
                    await context.Forward(new BasicQnAMakerPreviewDialog(), AfterAnswerAsync, message, CancellationToken.None);
                else
                    await context.Forward(new BasicQnAMakerDialog(), AfterAnswerAsync, message, CancellationToken.None);
            }
            else
            {
                await context.PostAsync("Please set QnAKnowledgebaseId, QnAAuthKey and QnAEndpointHostName (if applicable) in App Settings. Learn how to get them at https://aka.ms/qnaabssetup.");
            }

        }

        private async Task AfterAnswerAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            // wait for the next user message
            context.Wait(MessageReceivedAsync);
        }

        // The Utils.GetAppSetting(string key) method is for bots running on Azure 
        /*public static string GetSetting(string key)
        {
            var value = Utils.GetAppSetting(key);
            if (String.IsNullOrEmpty(value) && key == "QnAAuthKey")
            {
                value = Utils.GetAppSetting("QnASubscriptionKey"); // QnASubscriptionKey for backward compatibility with QnAMaker (Preview)
            }
            return value;
        }*/

        // Run your bot application on local and access settings from your web.config file
        public static string AppSettings(string key)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (String.IsNullOrEmpty(value) && key == "QnAAuthKey")
            {
                value = ConfigurationManager.AppSettings["QnASubscriptionKey"]; // QnASubscriptionKey for backward compatibility with QnAMaker (Preview)
            }
            return value;
        }
    }

    // Dialog for QnAMaker Preview service
    [Serializable]
    public class BasicQnAMakerPreviewDialog : QnAMakerDialog
    {
        // Go to https://qnamaker.ai and feed data, train & publish your QnA Knowledgebase.
        // Parameters to QnAMakerService are:
        // Required: subscriptionKey, knowledgebaseId, 
        // Optional: defaultMessage, scoreThreshold[Range 0.0 – 1.0]
        // The Utils.GetAppSetting(string key) method is for bots running on Azure
        /* public BasicQnAMakerPreviewDialog() : base(new QnAMakerService(new QnAMakerAttribute(RootDialog.GetSetting("QnAAuthKey"), Utils.GetAppSetting("QnAKnowledgebaseId"), "No good match in FAQ.", 0.5)))
         */
        //Run your bot application on local and access settings from your web.config file
        public BasicQnAMakerPreviewDialog() : base(new QnAMakerService(new QnAMakerAttribute(RootDialog.AppSettings("QnAAuthKey"), ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No good match in FAQ.", 0.5)))
        { }
    }

    // Dialog for QnAMaker GA service
    [Serializable]
    public class BasicQnAMakerDialog : QnAMakerDialog
    {
        // Go to https://qnamaker.ai and feed data, train & publish your QnA Knowledgebase.
        // Parameters to QnAMakerService are:
        // Required: qnaAuthKey, knowledgebaseId, endpointHostName
        // Optional: defaultMessage, scoreThreshold[Range 0.0 – 1.0]
        // The Utils.GetAppSetting(string key) method is for bots running on Azure
        /* public BasicQnAMakerDialog() : base(new QnAMakerService(new QnAMakerAttribute(RootDialog.GetSetting("QnAAuthKey"), Utils.GetAppSetting("QnAKnowledgebaseId"), "No good match in FAQ.", 0.5, 1, Utils.GetAppSetting("QnAEndpointHostName"))))
         */
        //Run your bot application on local and access settings from your web.config file
        public BasicQnAMakerDialog() : base(new QnAMakerService(new QnAMakerAttribute(RootDialog.AppSettings("QnAAuthKey"), ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No good match in FAQ.", 0.5, 1, ConfigurationManager.AppSettings["QnAEndpointHostName"])))
        { }
    }
}