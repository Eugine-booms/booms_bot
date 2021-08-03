using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramMyFirstBot.Model.Commands
{
    public abstract class Command
    {
        public abstract string []  Name { get; }

        public abstract  void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            foreach (var commandName in this.Name)
            {
                if (command.Contains(commandName.ToLower()))
                    return true;
            }
            return false;
            
        }
    }
}
