using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class WeatherCommand : Command
    {
        public override  string[] Name { get; } = new string[] { "/Погода", "/погод", "/weather"};

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            WeatherRequestFromUser weatherRequest=new WeatherRequestFromUser(message.Chat.Id, message.From.Username);
            Bot.userRequests.Add(weatherRequest);
        }

    }
}
