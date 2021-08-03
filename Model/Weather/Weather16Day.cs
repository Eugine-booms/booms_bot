using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using TelegramMyFirstBot.Model.Weather;

namespace TelegramMyFirstBot.Model.Conversations
{
    internal class Weather16Day : WeatherInCity
    {
        public override WeatherResponse Weather { get; set; }
        public WeatherResponse16  Weathers { get; set; }

        public override string WeatherAnswer()
        {
            var city = Weathers.GetCity();
            WeatherOfCity [] vars = Weathers.GetWeatherList();
            string answer = $"Город {city}";
            foreach (var temp in vars)
            {
                answer += $" {temp.Dt} {temp.Main.Temp} {temp.Weather.Description}  \n";
            }
            return answer;
        }

        public override WeatherInCity WeatherInTheCity(string city)
        {
            try
            {
                string apiID = "2351aaee5394613fc0d14424239de2bd";
                string url = "https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&units=metric&lang=ru&appid=" + apiID;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                
                }
                Weathers = JsonConvert.DeserializeObject<WeatherResponse16>(response);
                var wqrqrw = Weathers.City.ToString();

                return this;
            }
            catch (System.Net.WebException)
            {

                Console.WriteLine("Возникло исключение класс Weather");
                this.exception = "ошибка";
                return this;
            }
        }
    }
}