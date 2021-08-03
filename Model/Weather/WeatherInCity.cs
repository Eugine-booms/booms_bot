using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace TelegramMyFirstBot.Model
{
    public abstract class WeatherInCity
    {
        
        protected string exception=string.Empty;

        public abstract WeatherResponse Weather { get; set; }

        public abstract WeatherInCity WeatherInTheCity(string city);

        public abstract string WeatherAnswer();
    }
}
