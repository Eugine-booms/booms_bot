using System;
using System.IO;
using System.Net;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model.Weather
{
  abstract   public class RequestToServer
    {
        protected abstract string ApiID { get; set; }
        public string SendDataRequestToServer(WebRequest request)
        {
            if (request == null) throw new ArgumentException();
            string response;
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)request;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest?.GetResponse();
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = streamReader.ReadToEnd();
                }
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Возникло исключение класс RequestToWeatherSerwer");
                return "ошибка интернета";
            }
            return response;
        }
        abstract public WebRequest CreationDataToRequestWithParam(City city, string param);
    }
}