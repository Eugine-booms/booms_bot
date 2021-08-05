using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramMyFirstBot.Model.Commands;
using TelegramMyFirstBot.Model.Weather;

namespace TelegramMyFirstBot.Model.Conversations

{
    public class WeatherConversation
    {
        int step = 1;
        WeatherInCity weather;
        public async Task StarWeatherUserDialogAsync(global::Telegram.Bot.Types.Message msg)
        {
            var mre = new ManualResetEvent(false);

            EventHandler<MessageEventArgs> mHandler = (sender, e) =>
            {
                if (msg.From.Id != e.Message.From.Id) return;
                if (msg.Chat.Id != e.Message.Chat.Id) return;
                else if (step == 1)
                {
                    if (e.Message.Text == "Сейчас")
                    {
                        weather = new WeatherNow();
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());
                    } else if (e.Message.Text == "Hourly Forecast 4 days")
                    {
                        weather = new Weather4Day();
                        step++;
                       
                        
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());

                    } else if (e.Message.Text == "Daily Forecast 16 days")
                    {
                        weather = new Weather16Day();
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardMarkup());
                    } 
                    else
                    {
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "Нажми на кнопку!");
                        return;
                    }
                }
                else if (step == 2)
                {
                    if (!string.IsNullOrEmpty(e.Message.Text))
                    {
                        step++;
                        weather = weather.WeatherInTheCity(e.Message.Text);
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, weather.WeatherAnswer(), replyMarkup : Bot.ReturnStartSetOfButtons());
                        mre.Set();

                    }
                    else
                    {
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "Я все еще жду город?");
                    } 
                }
            };
            await Bot.Client.SendTextMessageAsync(msg.Chat.Id, $"Какую погоду ды хочешь узнать?", replyMarkup: Bot.ReturnSetOfButtonsWithTextParam(new string[] { "Сейчас", "Hourly Forecast 4 days", "Daily Forecast 16 days" }));
            Bot.Client.OnMessage += mHandler;
          //  Bot.Client.OnMessage -= Bot.OnMessageHandler;
            mre.WaitOne();
            Bot.Client.OnMessage -= mHandler;
          //  Bot.Client.OnMessage += Bot.OnMessageHandler;
        }

    }
}
