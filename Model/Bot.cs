using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot.Model.Commands
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        public static TelegramBotClient GetClient() => client;
        public static void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Console.WriteLine($"[log]: Пришло сообщение от : {message.From.FirstName} с текстом {message.Text}");
          
            foreach (var command in commandsList)
            {
                if (command.Contains(message.Text.ToLower()))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            //if (e.Message != null && e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text && !string.IsNullOrEmpty(e.Message.Text))
            //{
            //    try
            //    {
            //        if (e.Message.Text.ToLower().Contains("привет"))
            //         Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "Привет мой кожаный друг");
                    
            //        if (e.Message.Text.ToLower().Contains("как дела"))
            //        {
            //            Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "еще живой");
            //        }
            //        else
            //        {
            //            Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "Че надо");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.ToString());
            //    }

            //}
        }
        public static void Init()
        {
            client = new TelegramBotClient(AppSettings.Key) {Timeout = TimeSpan.FromSeconds(10) };
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            //TODO: Add more commands
        }    
    }
}