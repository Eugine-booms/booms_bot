using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model.Weather
{
    public class RequestToWeatherSerwer
    {
        private Dictionary<string, string> requestParam;
        
        protected string url { get; set; } = string.Empty;
        protected const string apiID = "2351aaee5394613fc0d14424239de2bd";
        private string serverAnswer;
        public string GetServerAnswer()
        {
            return this.serverAnswer;
        }

        public RequestToWeatherSerwer()
        {
            requestParam = new Dictionary<string, string>(3);
            requestParam.Add("Сейчас", "https://api.openweathermap.org/data/2.5/weather?q=");

            requestParam.Add("16 days", "https://api.openweathermap.org/data/2.5/forecast?q=");
        }
        public string CreationDataRequestWithParam(string city, string param)
        {
             this.url = requestParam[param] + city + "&units=metric&lang=ru&appid=" + RequestToWeatherSerwer.apiID;
            return url;        }
        public string SendDataRequestToServer(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException();
            string response;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Возникло исключение класс Weather");
                return "ошибка интернета";
            }
            this.serverAnswer = response;
            return "Ok";
        }
    }

}
