using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramMyFirstBot.Model.Weather.JsonRespParser
{
    public class WeatherRespond16Day : WeatherResponse, IWeatherParser
    {
        public City City { get; set; }
        public WeatherArray[] List { get; set; }

        public string GeneratesTextResponseForTheUser()
        {
            string answer = $"Погода в городу {City.Name} на 16 дней:";
                foreach (var temp in List)
            {
                answer += $" {temp.Dt_txt}  -  {temp.Main.Temp} °C"; 
            }
            return answer;
        }
    }

    public class WeatherArray
    {
        public Main Main { get; set; }
        public string Dt_txt { get; set; }
    }
}
  