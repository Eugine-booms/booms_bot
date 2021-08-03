using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramMyFirstBot.Model.Commands
{
    class WeatherCommand : Command
    {
        public override  string[] Name { get; } = new string[] { "/Погода", "/погод", "/weather"};

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            await client.SendTextMessageAsync(message.Chat.Id, message.Text, replyMarkup: Bot.GetButtons(new string[] { "Сейчас", "Hourly Forecast 4 days", "Daily Forecast 16 days", "Climatic Forecast 30 days" }));
            //    new ReplyKeyboardMarkup
            //    {
            //        Keyboard = new List<List<KeyboardButton>>
            //        {
            //        new List<KeyboardButton> {
            //            new KeyboardButton { Text = "Сейчас" },
            //            new KeyboardButton { Text = "Hourly Forecast 4 days" },
            //            new KeyboardButton { Text = "Daily Forecast 16 days" },
            //            new KeyboardButton { Text = "Climatic Forecast 30 days" } }
            //        }
            //    }
            //); ;
            var messagePars = message.Text.Split(' ');
            if (messagePars.Length > 1)
            {
                var city = message.Text.Split(' ')[1];
                var weather = new WeatherInCity(city);
                var answer = weather.WeatherAnswer();
                await client.SendTextMessageAsync(chatId, answer, replyToMessageId: messageId);
            }
            else
            {
                await client.SendTextMessageAsync(chatId, "Пиши \"/погода город\"", replyToMessageId: messageId);
            }
            
           



        }
    }
}
