using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class StickerCommand : Command
    {
        public override string[] Name { get; } = new string[] { "Стикер" }; 

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var stic = await client.SendStickerAsync(
                chatId: message.Chat.Id,
                sticker: "https://cdn.tlgrm.ru/stickers/dc7/a36/dc7a3659-1457-4506-9294-0d28f529bb0a/192/1.webp",
                replyToMessageId: message.MessageId,
                replyMarkup: Bot.GetButtons());
        }
    }
}
