using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            //var receiverOptions = new ReceiverOptions
            //{
            //    AllowedUpdates = { } // receive all update types
            //};
            //var updateReceiver = new QueuedUpdateReceiver(Bot.Client, receiverOptions);
            //Bot.Client.StartReceiving(
            //    HandleUpdateAsync,
            //    HandleErrorAsync,
            //    receiverOptions,
            //    cancellationToken
            //);
            Bot.Init();
            Bot.Client.StartReceiving();
            Bot.Client.OnMessage += Bot.OnMessageHandler;
            Console.ReadLine();
            Bot.Client.StopReceiving();
            cts.Cancel();

        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is Message message)
            {
                await botClient.SendTextMessageAsync(message.Chat, "Hello");
            }
        }

        static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                await botClient.SendTextMessageAsync(123, apiRequestException.ToString());
            }
        }
    }

}