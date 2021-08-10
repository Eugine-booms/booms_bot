using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model.Commands
{
    class  ActionPhoto 
        {
       
        public bool Contains(Message action)
        {
            return action.Type == Telegram.Bot.Types.Enums.MessageType.Photo;
        }
        public async Task ExecuteAsync(Message message, TelegramBotClient client) 
        {
            var file = await Bot.Client.GetFileAsync(message.Photo[message.Photo.Length - 1].FileId);
            using (FileStream fs = new FileStream(message.Photo.ToString(), FileMode.Create))
            {
                await Bot.Client.DownloadFileAsync(file.FilePath, fs);
                Bot.Client.SendTextMessageAsync(message.Chat.Id, "Image save");
                fs.Close();
                fs.Dispose();
            }
        }
    }
}
