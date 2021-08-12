using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    internal class TranslateRequest
    {
        private Message message;

        public TranslateRequest(Message message)
        {
            this.message = message;
        }
    }
}