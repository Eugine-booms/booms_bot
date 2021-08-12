using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model.Weather
{
    public class RequestToOpenWeatherServer: RequestToServer
    {
        private Dictionary<string, string> requestParam;
        private const string OpenWeatherParam = "&units=metric&lang=ru&appid=";

        protected override string ApiID { get; set; }="2351aaee5394613fc0d14424239de2bd";

        public RequestToOpenWeatherServer()
        {
            requestParam = new Dictionary<string, string>(3);
            requestParam.Add("Сейчас", "https://api.openweathermap.org/data/2.5/weather?q=");
            requestParam.Add("7 days", "https://api.openweathermap.org/data/2.5/weather?q=");
            requestParam.Add("16 days", "https://api.openweathermap.org/data/2.5/forecast?q=");
        }
        public override WebRequest CreationDataToRequestWithParam(City city, string param)
        {
            string url = requestParam[param] + city.Name + OpenWeatherParam + ApiID;
            return WebRequest.Create(url);      
        }
    }

}
