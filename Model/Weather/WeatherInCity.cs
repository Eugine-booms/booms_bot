using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model
{
    public class WeatherInCity
    {
        WeatherResponse weather;
        string exception=string.Empty;
        public WeatherInCity (string city)
        {
            try
            {
                string apiID= "2351aaee5394613fc0d14424239de2bd";
                string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&lang=ru&appid=" + apiID;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                weather = JsonConvert.DeserializeObject<WeatherResponse>(response);
                
            }
            catch (System.Net.WebException)
            {
                
                Console.WriteLine("Возникло исключение класс Weather");
                this.exception="ошибка";

            }
        }
        public string WeatherAnswer() 
        {
            if (string.IsNullOrEmpty(exception))
            {

                return $"Сейчас в городе { weather.Name } " +
                    $"{ weather.Main.Temp:F1} °C, \n " +
                    $"ощущается как {weather.Main.Feels_like}, " +
                    $"{weather.Weather[0].Description},  " +
                    $"ветер {weather.Wind.Speed} м/с, \n" +
                    $"влажность {weather.Main.Humidity} %, " +
                    $"давление {weather.Main.Pressure} mmHg \n " +
                    $"максимальная температура {weather.Main.Temp_max} \n" +
                    $"минимальная {weather.Main.Temp_min}";
            }
            else return "я чет не понял";

        }

        
    }
}
