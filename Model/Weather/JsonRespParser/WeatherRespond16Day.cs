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

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coodr Coodr { get; set; }
        public City()
        {
            Coodr = new Coodr();
        }
        public Coodr CityGetCoord()
        {
            RequestToWeatherSerwer coordRequest = new RequestToWeatherSerwer();
            var urlRequest= coordRequest.CreationDataRequestToOpenWeatherWithParam(this, "Сейчас");
            var answer = coordRequest.SendDataRequestToServer(urlRequest);
            WeatherRespondNow temp= WeatherRequestFromUser.ConvertFromJSON<WeatherRespondNow>(answer);
            Coodr.Lat = temp.Coord.Lat;
            Coodr.Lon = temp.Coord.Lon;
            return this.Coodr;
        }

    }

    public class WeatherArray
    {
        public Main Main { get; set; }
        public string Dt_txt { get; set; }
    }
}
  