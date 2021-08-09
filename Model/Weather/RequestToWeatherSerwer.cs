using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model.Weather
{
    public class RequestToWeatherSerwer
    {
        private Dictionary<string, string> requestParam;
        protected const string OpenWeatherApiID = "2351aaee5394613fc0d14424239de2bd";
        protected const string OpenWeatherParam = "&units=metric&lang=ru&appid=";
        public RequestToWeatherSerwer()
        {
            requestParam = new Dictionary<string, string>(3);
            requestParam.Add("Сейчас", "https://api.openweathermap.org/data/2.5/weather?q=");
            requestParam.Add("7 days", "https://api.openweathermap.org/data/2.5/weather?q=");
            requestParam.Add("16 days", "https://api.openweathermap.org/data/2.5/forecast?q=");
        }
        public WebRequest CreationDataRequestToOpenWeatherWithParam(City city, string param)
        {
            string url = requestParam[param] + city.Name + OpenWeatherParam + RequestToWeatherSerwer.OpenWeatherApiID;
            return WebRequest.Create(url);      
        }
        public WebRequest CreationDataRequestToYandexWithParam(City city)
        {
            var coordOfCity= city.CityGetCoord();
            string url = $"https://api.weather.yandex.ru/v2/forecast?lat=" + coordOfCity.Lat + "&lon" + coordOfCity.Lon+ "&limit=7";
            WebRequest request= WebRequest.Create(url);
            request.Headers.Add("X-Yandex-API-Key:ff8e8cc7-0fbb-4b54-a494-0dbdfbcb371e");
            return request;
        }
        public string SendDataRequestToServer(WebRequest request)
        {
            if (request==null) throw new ArgumentException();
            string response;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)request;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
                File.WriteAllText(@"response.json", response);
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Возникло исключение класс RequestToWeatherSerwer");
                return "ошибка интернета";
            }
            return response;
        }
    }

}
