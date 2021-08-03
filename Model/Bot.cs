using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
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
            try
            {
                var message = e.Message;
                Console.WriteLine($"[log]: Пришло сообщение типа {e.Message.Type} от : {message.From.FirstName} с текстом {message.Text}");

                if (message.Text != null)

                    await Bot.client.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: GetButtons());

                foreach (var command in commandsList)
                {
                    if (message.Text != null && command.Contains(message.Text.ToLower()))
                    {
                        command.Execute(message, client);
                        break;
                    }
                }
                
            }

            catch (Exception)
            {
               
                Console.WriteLine("[err]Возникло исключение сообщение боту");
                
            }
        
        }

        public static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Привет" }, new KeyboardButton { Text = "Погода" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Стикер" }, new KeyboardButton { Text = "Картинка" } }
                }
            };
        }

        public static void Init()
        {
            client = new TelegramBotClient(AppSettings.Key) {Timeout = TimeSpan.FromSeconds(10) };
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            commandsList.Add(new WeatherCommand());
            commandsList.Add(new StickerCommand());
            commandsList.Add(new ImageCommand());
            //TODO: Add more commands
        }    
    }
}