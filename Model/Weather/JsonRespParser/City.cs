using Newtonsoft.Json.Linq;

namespace TelegramMyFirstBot.Model.Weather.JsonRespParser
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Coodr Coodr { get; set; }
        public City()
        {
            Coodr = new Coodr();
        }
        public Coodr GetСoordinates(string name)
        {
            RequestToOpenWeatherServer coordRequest = new RequestToOpenWeatherServer();
            var urlRequest= coordRequest.CreationDataToRequestWithParam(this, "Сейчас");
            var answer = coordRequest.SendDataRequestToServer(urlRequest);
            dynamic json = JObject.Parse(answer);
            Coodr.Lat = json.coord.lat;
            Coodr.Lon = json.coord.lon;
            return this.Coodr;
        }

    }
}
  