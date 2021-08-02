using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot
{
    class Program
    {
        //private static string token = "1923534611:AAExZTnhxn7pSIsSOmu4Iqln-OqF4ZITlSM";
        //private static TelegramBotClient client;
        static void Main(string[] args)
        {
            Bot.Init();
            var client = Bot.GetClient();
            
            client.StartReceiving();   // начинаем слушать входяжие сообщения
            
            client.OnMessage += Bot.OnMessageHandler;
           
            Console.ReadLine();
            client.StopReceiving();
        }

       

      
    }
}
