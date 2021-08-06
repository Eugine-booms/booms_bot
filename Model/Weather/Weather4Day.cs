using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model.Weather
{
    class Weather4Day : WeatherRequestFromUser
    {
        public override WeatherResponse Weather { get; set; }

        public override string WeatherAnswer()
        {
            if (string.IsNullOrEmpty(exception))
            {

                return $"Сейчас в городе { Weather.Name } " +
                    $"{ Weather.Main.Temp:F1} °C, \n " +
                    $"ощущается как {Weather.Main.Feels_like}, " +
                    $"{Weather.Weather[0].Description},  " +
                    $"ветер {Weather.Wind.Speed} м/с, \n" +
                    $"влажность {Weather.Main.Humidity} %, " +
                    $"давление {Weather.Main.Pressure} mmHg \n " +
                    $"максимальная температура {Weather.Main.Temp_max} \n" +
                    $"минимальная {Weather.Main.Temp_min}";
            }
            else return "я чет не понял"; throw new NotImplementedException();
        }

        public override WeatherRequestFromUser WeatherInTheCity(string city)
        {
            try
            {
                string apiID = "2351aaee5394613fc0d14424239de2bd";
                string url = "https://pro.openweathermap.org/data/2.5/forecast/hourly?q=" + city + "&units=metric&lang=ru&appid=" + apiID;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                this.Weather = JsonConvert.DeserializeObject<WeatherResponse>(response);
                return this;
            }
            catch (System.Net.WebException e)
            {

                Console.WriteLine("Возникло исключение класс Weather");
                this.exception = "ошибка";
                return this;
            }
        }
    }
}
