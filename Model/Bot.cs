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

            if (e.Message != null && e.Message.Type == Telegram.Bot.Types.Enums.MessageType.Text && !string.IsNullOrEmpty(e.Message.Text))
            {
                try
                {
                    if (e.Message.Text.ToLower().Contains("привет"))
                        Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "Привет мой кожаный друг");
                    else
                    if (e.Message.Text.ToLower().Contains("как дела"))
                    {
                        Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "еще живой");
                    }
                    else
                    {
                        Bot.GetClient().SendTextMessageAsync(e.Message.Chat.Id, "Че надо");
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        public static void Init()
        {
           
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            //TODO: Add more commands

            client = new TelegramBotClient(AppSettings.Key);
           

           
        }
    }
}