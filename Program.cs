using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot.Init();
            var client = Bot.GetClient();
            client.StartReceiving();   // начинаем слушать входящие сообщения
            client.OnMessage += Bot.OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }
    }
}
