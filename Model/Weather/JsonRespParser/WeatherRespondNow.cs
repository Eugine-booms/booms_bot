using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramMyFirstBot.Model.Weather.JsonRespParser
{
    class WeatherRespondNow:WeatherResponse, IWeatherParser
    {
        public Coodr Coord { get; set; }
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Name { get; set; }

        public string GeneratesTextResponseForTheUser()
        {
            return $"Сейчас в городе { this.Name } " +
                   $"{ Main.Temp:F1} °C, \n " +
                   $"ощущается как {Main.Feels_like}, " +
                   $"{Weather[0].Description},  " +
                   $"ветер {Wind.Speed} м/с, \n" +
                   $"влажность {Main.Humidity} %, " +
                   $"давление {Main.Pressure} mmHg \n " +
                   $"максимальная температура {Main.Temp_max} \n" +
                   $"минимальная {Main.Temp_min}";
        }
    }

    public class Coodr
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }

    public class Main
    {
        public float Temp { get; set; }
        public float Feels_like { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
    public class Wind
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
    }
    public class Clouds
    {
        public int All { get; set; }
    }
    public class Weather
    {
        public string Description { get; set; }
    }

}
