using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    class TranslateComand : Command
    {
        public override string[] Name { get; } = new string[] { "перевод","переведи" };
        public override void Execute(Message message, TelegramBotClient client)
        {
            new TranslateRequest(message);
            var a = message.Text.ToLower().Split(' ');
        }
    }
}
      