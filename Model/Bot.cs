using System;
using System.Collections.Generic;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot.Exceptions;

namespace TelegramMyFirstBot.Model.Commands
{
    public static class Bot
    {
        public static List<WeatherRequestFromUser> userRequests = new List<WeatherRequestFromUser>();
        
        public static TelegramBotClient Client { get; private set; }
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        private static void LogMessage(MessageEventArgs incomingMessage) 
        {
            Console.WriteLine($"[log]: Пришло сообщение типа {incomingMessage.Message.Type} от : {incomingMessage.Message.From.FirstName} с текстом {incomingMessage.Message.Text}");
        }
        public static async void OnMessageHandler(object sender, MessageEventArgs incoming)
        {
            LogMessage(incoming);
            
            if (incoming.Message.Text == null || incoming.Message.Text == string.Empty)
                return;
            try
            {
                foreach (var command in commandsList)
                {
                    //var a = incoming.Message.Text.ToLower().Split(' ');
                    if (command.Contains(incoming.Message.Text.ToLower().Split(' ')[0]))
                    {
                        command.Execute(incoming.Message, Client);
                        break;
                    }
                }
                if (userRequests.Count != 0)
                {
                    foreach(var temp in userRequests)
                    {
                      await temp.WeatherUserDialogAsync(incoming.Message);
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[err]Возникло исключение сообщение боту" + e.ToString());
            }
        }
        public static IReplyMarkup ReturnStartSetOfButtons()
        {
           return new ReplyKeyboardMarkup(
               new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Привет" }, new KeyboardButton { Text = "/Погода" }},
                    new List<KeyboardButton> { new KeyboardButton { Text = "Стикер" }, new KeyboardButton { Text = "Картинка" }}
                }, true, true);
           
        }
        public static IReplyMarkup ReturnSetOfButtonsWithTextParam(string[] buttonText)
        {
            var buttonList = new List<KeyboardButton>();
            
            foreach (var text in buttonText)
            {
                buttonList.Add(new KeyboardButton { Text = text });
            }
            return new ReplyKeyboardMarkup(new List<List<KeyboardButton>> { buttonList },  resizeKeyboard: true, oneTimeKeyboard: true); 
        }
        public static void Init()
        {
            Client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            var me = Client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            commandsList.Add(new WeatherCommand());
            commandsList.Add(new StickerCommand());
            commandsList.Add(new ImageCommand());
            commandsList.Add(new TranslateComand());
            //TODO: Add more commands
        }
    }
}
