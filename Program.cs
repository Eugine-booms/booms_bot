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
            Bot.Init();
            Bot.Client.StartReceiving();
            Bot.Client.OnMessage += Bot.OnMessageHandler;
            Console.ReadLine();
            Bot.Client.StopReceiving();

        }
    }
}