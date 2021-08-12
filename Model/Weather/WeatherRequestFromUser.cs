using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramMyFirstBot.Model.Commands;
using TelegramMyFirstBot.Model.Weather;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model
{
    public class WeatherRequestFromUser
    {
        public int Step { get; set; } = 0;
        //private RequestToServer requestServer;
        public ChatId ChatId { get; set; }
        public string Username { get; set; }
        protected string WeatherTypeSelection { get; set; }
        protected City City {get; set;}
        public WeatherRequestFromUser(ChatId chatID, string username)
        {
            City = new City();
            this.ChatId = chatID;
            this.Username = username;
        }
        public static  IWeatherParser ConvertFromJSON <IWeatherParser> (string answer)
        {
            IWeatherParser weather;
            weather = JsonConvert.DeserializeObject<IWeatherParser>(answer);
            return weather;
        }

        public string CreateWeatherAnswer()
        {
            IWeatherParser weather;
            //var pingRequestServer = new RequestToOpenWeatherServer();
            //var pingRequestData = pingRequestServer.CreationDataToRequestWithParam(City, WeatherTypeSelection);
            
            if (WeatherTypeSelection == "Сейчас")
            {
                var requestServer = new RequestToOpenWeatherServer();
                var requestData = requestServer.CreationDataToRequestWithParam(City, WeatherTypeSelection);
                var serverAnswerString = requestServer.SendDataRequestToServer(requestData);
                if (serverAnswerString == "ошибка интернета")
                    return "Шеф, это провал! У нас ошибка запроса на сервер";
                weather = ConvertFromJSON<WeatherRespondNow>(serverAnswerString);
            }
            else
             if (WeatherTypeSelection == "7 days")
            {
                var requestServer = new RequestToYandexWeatherServer();
                City.GetСoordinates();
                if (City.Coodr.Lat<0||City.Coodr.Lon<0)
                    return $"Сам ты {City.Name}";
                var requestData = requestServer.CreationDataToRequestWithParam(City, null);
                var serverAnswerString = requestServer.SendDataRequestToServer(requestData);
                if (serverAnswerString == "ошибка интернета")
                    return "Шеф, это провал! У нас ошибка запроса на сервер";
                weather = ConvertFromJSON<YandexWeatherResponse>(serverAnswerString);
            }
            else
            if (WeatherTypeSelection == "16 days")
            {
                var requestServer = new RequestToOpenWeatherServer();
                var requestData = requestServer.CreationDataToRequestWithParam(City, WeatherTypeSelection);
                var serverAnswerString = requestServer.SendDataRequestToServer(requestData);
                if (serverAnswerString == "ошибка интернета")
                    return "Шеф, это провал! У нас ошибка запроса на сервер";
                weather = JsonConvert.DeserializeObject<WeatherRespond16Day>(serverAnswerString);
            }
            else weather = new WeatherRespondNow();
                return weather.GeneratesTextResponseForTheUser();
             
        }
        public void AnswerToUser(Message msg)
        {
            Bot.Client.SendTextMessageAsync(ChatId, CreateWeatherAnswer(), replyToMessageId: msg.MessageId, replyMarkup: Bot.ReturnStartSetOfButtons());
        }
        //public static async void OnMessageHandler(object sender, MessageEventArgs incoming)
       public async void OnCallbackQueryDialog (object sc, Telegram.Bot.Args.CallbackQueryEventArgs ev) 
        { 
            var message = ev.CallbackQuery.Message;
            Console.WriteLine($"[log]: OnCallbackQuery {message.Type} от : {ev.CallbackQuery.From.FirstName} с текстом {message.Text}");
            if (ev.CallbackQuery.From.Username != Username)
                return;
            WeatherTypeSelection = ev.CallbackQuery.Data;
            Step++;
            await Bot.Client.AnswerCallbackQueryAsync(ev.CallbackQuery.Id); // отсылаем пустое, чтобы убрать "частики" на кнопке
            await Bot.Client.SendTextMessageAsync(message.Chat.Id, "В каком городе?", replyToMessageId: message.MessageId, replyMarkup: new ForceReplyMarkup());
        }
        public async Task WeatherUserDialogAsync(Message msg)
        {
            if (this.Username != msg.From.Username) return;
            if (this.ChatId != msg.Chat.Id) return;
            if (Step == 0)
            {
                var keyboard = Bot.ReturnSetOfButtonsInlineWithTextParam(new string[] { "Сейчас", "7 days", "16 days" });
                await Bot.Client.SendTextMessageAsync(ChatId, $"Какую погоду ды хочешь узнать?", replyToMessageId: msg.MessageId, replyMarkup: keyboard);
                Bot.Client.OnCallbackQuery += OnCallbackQueryDialog;
                Step++;
            }
            else if (Step == 2)
            {
                if (!string.IsNullOrEmpty(msg.Text))
                {
                    City.Name = msg.Text;
                    AnswerToUser(msg);
                    Step=-1;
                    Bot.Client.OnCallbackQuery -= OnCallbackQueryDialog;
                }
                else
                {
                    await Bot.Client.SendTextMessageAsync(ChatId, "Я все еще жду город?", replyToMessageId: msg.MessageId);
                }
            }
        }
    }
}
