using System;
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