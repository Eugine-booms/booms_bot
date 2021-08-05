﻿using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramMyFirstBot.Model.Conversations;

namespace TelegramMyFirstBot.Model.Commands
{
    class WeatherCommand : Command
    {
        public override  string[] Name { get; } = new string[] { "/Погода", "/погод", "/weather"};

        public override async void Execute(Message message, TelegramBotClient client)
        {
            //var chatId = message.Chat.Id;
            //var messageId = message.MessageId;
            WeatherConversation a=new WeatherConversation();
            await a.StarWeatherUserDialogAsync(message);
            //Bot.Client.OnMessage -=mHandler;
        }
    }
}
