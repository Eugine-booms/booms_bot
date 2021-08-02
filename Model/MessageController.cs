using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot.Model
{
    class MessageController: ApiController
    {
        //public async Task<OkResult> Update()
        //{
        //    var commands = Bot.Commands;
        //    var message = update.Message;
        //    var client = await Bot.Get();

        //    foreach (var command in commands)
        //    {
        //        if (command.Contains(message.Text))
        //        {
        //            command.Execute(message, client);
        //            break;
        //        }
        //    }

        //    return Ok();
        //}
    }
}
