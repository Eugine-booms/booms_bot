namespace TelegramMyFirstBot.Model
{
    internal class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public CloudInfo [] Weather { get; set; }
        public WindInfo  Wind { get; set; }
        public string Name { get; set; }
        
    }
    
}