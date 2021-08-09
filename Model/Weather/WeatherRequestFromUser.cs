using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
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
    public class WeatherRequestFromUser
    {
        int step = 0;
        private RequestToWeatherSerwer requestSerwer;
        public ChatId ChatId { get; set; }
        public string Username { get; set; }
        protected string WeatherTypeSelection { get; set; }
        //protected string WeatherCitySelection { get; set; }
        protected City City {get; set;}
        public WeatherRequestFromUser(ChatId chatID, string username)
        {
            requestSerwer = new RequestToWeatherSerwer();
            City = new City();
            this.ChatId = chatID;
            this.Username = username;
        }
        public static  IWeatherParser ConvertFromJSON <IWeatherParser> (string answer)
        {
            IWeatherParser weather;
            weather= JsonConvert.DeserializeObject<IWeatherParser>(answer);
            return weather;
        }

        public string CreateWeatherAnswer()
        {
            IWeatherParser weather;
            if (WeatherTypeSelection == "Сейчас")
            {
                var requestData = requestSerwer.CreationDataRequestToOpenWeatherWithParam(City, WeatherTypeSelection);
                var serverAnswerString = requestSerwer.SendDataRequestToServer(requestData);
                weather = ConvertFromJSON<WeatherRespondNow>(serverAnswerString);
            }
            else
             if (WeatherTypeSelection == "7 days")
            {
                var requestData = requestSerwer.CreationDataRequestToYandexWithParam(City);
                var serverAnswerString = requestSerwer.SendDataRequestToServer(requestData);
                weather = ConvertFromJSON<YandexWeatherResponse>(serverAnswerString);
            }
            else
            if (WeatherTypeSelection == "16 days")
            {
                var requestData = requestSerwer.CreationDataRequestToOpenWeatherWithParam(City, WeatherTypeSelection);
                var serverAnswerString = requestSerwer.SendDataRequestToServer(requestData);
                weather = JsonConvert.DeserializeObject<WeatherRespond16Day>(serverAnswerString);
            }
            else weather = new WeatherRespondNow();
            return weather.GeneratesTextResponseForTheUser();
        }
        private void AnswerToUser()
        {
            Bot.Client.SendTextMessageAsync(ChatId, CreateWeatherAnswer(), replyMarkup: Bot.ReturnStartSetOfButtons());
        }
        public async Task WeatherUserDialogAsync(Message msg)
        {
            if (this.Username != msg.From.Username) return;
            if (this.ChatId != msg.Chat.Id) return;
            if (step == 0)
            {
                await Bot.Client.SendTextMessageAsync(ChatId, $"Какую погоду ды хочешь узнать?", replyToMessageId: msg.MessageId, replyMarkup: Bot.ReturnSetOfButtonsWithTextParam(new string[] { "Сейчас", "7 days", "16 days" })); ;
                step++;
            }
            else if (step == 1)
            {
                if (msg.Text == "Сейчас")
                {
                    WeatherTypeSelection = "Сейчас";
                    step++;
                    await Bot.Client.SendTextMessageAsync(ChatId, "В каком городе?", replyToMessageId: msg.MessageId, replyMarkup: new ReplyKeyboardRemove());
                }
                else
                if (msg.Text == "7 days")
                {
                    WeatherTypeSelection = "7 days";
                    step++;
                    await Bot.Client.SendTextMessageAsync(ChatId, "В каком городе?", replyToMessageId: msg.MessageId, replyMarkup: new ReplyKeyboardRemove());
                }
                else 
                if (msg.Text == "16 days")
                {
                    WeatherTypeSelection = "16 days";
                    step++;
                    await Bot.Client.SendTextMessageAsync(ChatId, "В каком городе?", replyToMessageId: msg.MessageId, replyMarkup: new ReplyKeyboardRemove());
                }
                else
                {
                    await Bot.Client.SendTextMessageAsync(ChatId, "Нажми на кнопку!", replyToMessageId: msg.MessageId);
                    return;
                }
            }
            else if (step == 2)
            {
                if (!string.IsNullOrEmpty(msg.Text))
                {
                    step++;
                    City.Name = msg.Text;
                    AnswerToUser();
                    Bot.userRequests.Remove(this);
                }
                else
                {
                    await Bot.Client.SendTextMessageAsync(ChatId, "Я все еще жду город?", replyToMessageId: msg.MessageId);
                }
            }
        }
    }
}
