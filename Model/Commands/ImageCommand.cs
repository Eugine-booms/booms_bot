using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class ImageCommand : Command
    {
        public override  string[] Name { get; } = new string[] { "картинка" };

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var image = await client.SendPhotoAsync (
               chatId: message.Chat.Id,
               photo: "https://static7.depositphotos.com/1219281/708/i/950/depositphotos_7082441-stock-photo-beautiful-sunset-on-the-beach.jpg",
               replyToMessageId: message.MessageId,
               replyMarkup: Bot.ReturnStartSetOfButtons());
        }
    }
}
