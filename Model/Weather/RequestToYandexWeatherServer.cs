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
            var coordOfCity = city.GetСoordinates(city.Name);
            string url = $"https://api.weather.yandex.ru/v2/forecast?lat=" + coordOfCity.Lat + "&lon" + coordOfCity.Lon + "&limit=7";
            WebRequest request = WebRequest.Create(url);
            request.Headers.Add(ApiID);
            return request;
        }
    }
}
