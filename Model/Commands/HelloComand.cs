using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class HelloComand : Command
    {
        public override string Name => "Hello";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic -_-

            client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
}
