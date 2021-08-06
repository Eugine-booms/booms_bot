using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramMyFirstBot.Model.Commands;
using TelegramMyFirstBot.Model.Weather;

namespace TelegramMyFirstBot.Model
{
    public  class WeatherRequestFromUser
    {

        Dictionary<string, string> requestParam; 
        private RequestToWeatherSerwer requestSerwer ;
        public ChatId ChatId    { get; set; }
        public string Username  { get; set; }
        protected string WeatherTypeSelection { get; set; }
        protected string WeatherCitySelection { get; set; }
        public WeatherRequestFromUser(ChatId chatID, string  username)
        {
            this.ChatId = chatID;
            this.Username = username;
            requestParam = new Dictionary<string, string>(3);
            requestParam.Add("сейчас", "&units=metric&lang=ru&appid=");

        }
        public string CreateWeatherAnswer() { }
        private void AnswerToUser()
        {
            Bot.Client.SendTextMessageAsync(ChatId, CreateWeatherAnswer(), replyMarkup: Bot.ReturnStartSetOfButtons());
        }
        
        public async Task StarWeatherUserDialogAsync(Message msg)
        {
            var mre = new ManualResetEvent(false);
            int step = 1;
            EventHandler<MessageEventArgs> mHandler = (sender, e) =>
            {
                if (this.Username != e.Message.From.Username) return;
                if (msg.From.Id != e.Message.From.Id) return;
                if (this.ChatId != e.Message.Chat.Id) return;
                else if (step == 1)
                {
                    if (e.Message.Text == "Сейчас")
                    {
                        WeatherTypeSelection = e.Message.Text;
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());
                    }
                    else if (e.Message.Text == "Hourly Forecast 4 days")
                    {
                        WeatherTypeSelection = e.Message.Text;
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());
                    }
                    else if (e.Message.Text == "Daily Forecast 16 days")
                    {
                        WeatherTypeSelection = e.Message.Text;
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
                        WeatherCitySelection= e.Message.Text;
                        AnswerToUser();
                        //Bot.Client.SendTextMessageAsync(msg.Chat.Id, weather.WeatherAnswer(), replyMarkup: Bot.ReturnStartSetOfButtons());
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
            mre.WaitOne();
            Bot.Client.OnMessage -= mHandler;
        }
    }
}
