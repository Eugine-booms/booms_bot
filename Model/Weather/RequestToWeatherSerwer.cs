using System;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model.Weather
{
    public class RequestToWeatherSerwer
    {
        protected string url { get; set; } = string.Empty;
        protected const string apiID = "2351aaee5394613fc0d14424239de2bd";
        protected string ServerAnswer { get; set; }
        protected string CreationDataRequestWithParam(string param)
        {
            //один из трех вариантов параметра
            return 
        }
        protected string SendDataRequestToServer(string url)
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
            ServerAnswer = response;
            return "Ok";
        }
    }

}
