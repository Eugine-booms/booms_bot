using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace TelegramMyFirstBot.Model.Weather
{
    class WeatherResponse16
    {
        public object City { get; set; }
        public Object[] list { get; set; }

        public string GetCity()
        {
            string name = JsonConvert.DeserializeObject <nameOfCity> (City.ToString()).Name;
            return name;
        }
        public WeatherOfCity[] GetWeatherList()
        {
            WeatherOfCity [] temp1= new WeatherOfCity[list.Length];
            int i = 0;
            foreach (var temp in list)
            {
                temp1[i] = new WeatherOfCity();
                temp1[i]= JsonConvert.DeserializeObject<WeatherOfCity>(temp.ToString());
                i++;
            }
            return temp1;
        }
    }
    class nameOfCity
    {
        public string Name { get; set; }
    }
    class WeatherOfCity
    {
        public MainWeatherJSON Main { get; set; }
        public WeatherJSON Weather { get; set; }
        public string Dt { get; set; }
    }

    public class WeatherJSON
    {
        public string Description { get; set; }
    }

    public class MainWeatherJSON
    {
        public float Temp { get; set; }
        
    }
}
