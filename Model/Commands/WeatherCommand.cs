using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class WeatherCommand : Command
    {
        public override  string[] Name { get; } = new string[] { "/погода", "/погод", "/weather"};

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            var messagePars = message.Text.Split(' ');
            if (messagePars.Length > 1)
            {
                var city = message.Text.Split(' ')[1];
                var weather = new Weather(city);
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
