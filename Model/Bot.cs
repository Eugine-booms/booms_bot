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
        public static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            Console.WriteLine($"[log]: Пришло сообщение от : {message.From.FirstName} с текстом {message.Text}");
          
            foreach (var command in commandsList)
            {
                if (message.Text!= null && command.Contains(message.Text.ToLower()))
                {
                    command.Execute(message, client);
                    break;
                }
            }
        }

        public static void Init()
        {
            client = new TelegramBotClient(AppSettings.Key) {Timeout = TimeSpan.FromSeconds(10) };
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            commandsList.Add(new WeatherCommand());
            //TODO: Add more commands
        }    
    }
}