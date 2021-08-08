using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramMyFirstBot.Model.Weather.JsonRespParser
{
    interface IWeatherParser
    {
        public string GeneratesTextResponseForTheUser();
    }
}
