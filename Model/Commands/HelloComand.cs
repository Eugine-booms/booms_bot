using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    public class HelloComand : Command
    {
        public override string[] Name { get; } = new string[] { "hello", "Привет", "дарова", "здорова" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic -_-

           await client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }

}
