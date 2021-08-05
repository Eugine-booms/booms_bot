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
            Bot.Client.StartReceiving();   // начинаем слушать входящие сообщения
            Bot.Client.OnMessage += Bot.OnMessageHandler;
            Console.ReadLine();
            Bot.Client.StopReceiving();
        }
    }
}
