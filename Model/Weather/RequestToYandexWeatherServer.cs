using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TelegramMyFirstBot.Model.Weather.JsonRespParser;

namespace TelegramMyFirstBot.Model.Weather
{
    class RequestToYandexWeatherServer : RequestToServer
    {
        protected override string ApiID { get; set; } = "X-Yandex-API-Key:ff8e8cc7-0fbb-4b54-a494-0dbdfbcb371e";

        public override WebRequest CreationDataToRequestWithParam(City city, string param)
        {
            
            string url = $"https://api.weather.yandex.ru/v2/forecast?lat=" + city.Coodr.Lat + "&lon" + city.Coodr.Lon + "&limit=7";
            var request = WebRequest.Create(url);
            request.Headers.Add(ApiID);
            return request;
        }
    }
}
