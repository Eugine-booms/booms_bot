using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramMyFirstBot.Model.Commands;
using TelegramMyFirstBot.Model.Weather;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model
{
    public  class WeatherRequestFromUser
    {

        private RequestToWeatherSerwer requestSerwer;
        public ChatId ChatId    { get; set; }
        public string Username  { get; set; }
        protected string WeatherTypeSelection { get; set; }
        protected string WeatherCitySelection { get; set; }
        public WeatherRequestFromUser(ChatId chatID, string  username)
        {
            requestSerwer = new RequestToWeatherSerwer();
            this.ChatId = chatID;
            this.Username = username;
        }
        public string CreateWeatherAnswer()
        {
            var a1= requestSerwer.CreationDataRequestWithParam(WeatherCitySelection, WeatherTypeSelection);
            if (requestSerwer.SendDataRequestToServer(requestSerwer.CreationDataRequestWithParam(WeatherCitySelection, WeatherTypeSelection)) != "Ok")
                return "Ошибка запроса на сервер";
            string serverAnswerString = requestSerwer.GetServerAnswer();
            IWeatherParser weather;
            if (string.IsNullOrEmpty(serverAnswerString))
            {
                return "Ошибка: Пустой ответ сервера";
            }
            if (WeatherTypeSelection == "Сейчас")
            {
                weather = JsonConvert.DeserializeObject<WeatherRespondNow>(serverAnswerString);
            }else 
            
            if (WeatherTypeSelection == "16 days")
            {
                weather = JsonConvert.DeserializeObject<WeatherRespond16Day>(serverAnswerString);
            }
            else weather = new WeatherRespondNow();
            return weather.GeneratesTextResponseForTheUser();
        }
        private void AnswerToUser()
        {
            Bot.Client.SendTextMessageAsync(ChatId, CreateWeatherAnswer(), replyMarkup: Bot.ReturnStartSetOfButtons());
        }
        public async Task StarWeatherUserDialogAsync(Message msg)
        {
            //var mre = new ManualResetEvent(false);
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
                        WeatherTypeSelection = "Сейчас";
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());
                    }
                    else if (e.Message.Text == "Daily Forecast 16 days")
                    {
                        WeatherTypeSelection = "16 days";
                        step++;
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: new ReplyKeyboardRemove());
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
                       // mre.Set();

                    }
                    else
                    {
                        Bot.Client.SendTextMessageAsync(msg.Chat.Id, "Я все еще жду город?");
                    }
                }
            };
            await Bot.Client.SendTextMessageAsync(msg.Chat.Id, $"Какую погоду ды хочешь узнать?", replyMarkup: Bot.ReturnSetOfButtonsWithTextParam(new string[] { "Сейчас", "16 days" }));
            if (step == 1)
            Bot.Client.OnMessage += mHandler;
          //  mre.WaitOne();
          if (step==2)
            Bot.Client.OnMessage -= mHandler;
        }
    }
}
