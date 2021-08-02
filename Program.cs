using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramMyFirstBot
{
    class Program
    {
        private static string token = "1923534611:AAExZTnhxn7pSIsSOmu4Iqln-OqF4ZITlSM";
        private static TelegramBotClient client;
        static void Main(string[] args)
        {


            client = new TelegramBotClient(token);
            client.StartReceiving();   // начинаем слушать входяжие сообщения
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static void OnMessageHandler(object sender, MessageEventArgs e)
        {
           if (e.Message != null&& e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text && !string.IsNullOrEmpty(e.Message.Text))
            {
                try
                {
                    if (e.Message.Text.ToLower().Contains("привет"))
                    client.SendTextMessageAsync(e.Message.Chat.Id, "Привет мой кожаный друг");
                    else 
                    if (e.Message.Text.ToLower().Contains("как дела"))
                    {
                        client.SendTextMessageAsync(e.Message.Chat.Id, "еще живой");
                    }
                    else
                    {
                        client.SendTextMessageAsync(e.Message.Chat.Id, "Че надо");
                    }
                }
                catch (Exception ex)
                {

                }
                
            }
        }

      
    }
}
