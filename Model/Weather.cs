using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model
{
    public class Weather
    {
        static string nameOfCity;
        static float tempOfCity;
        public Weather (string city)
        {
            try
            {
                string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&unit=metric&appid=2351aaee5394613fc0d14424239de2bd";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                string response;

                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);

                nameOfCity = weatherResponse.Name;
                tempOfCity = weatherResponse.Main.Temp - 273;
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Возникло исключение класс Weather");
                return;
            }
        }
        public string WeatherAnswer() 
        {

            if (tempOfCity <= 10)
                return $" {tempOfCity} Сегодня в {nameOfCity} холодно одевайся потеплее!";
            else
            if (tempOfCity >= 25)
                return $"{tempOfCity} Сегодня в {nameOfCity} очень жарко";
            else
                return $" Сегодня в {nameOfCity} {tempOfCity}";

        }

        
    }
}
