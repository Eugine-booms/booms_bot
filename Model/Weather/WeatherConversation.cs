using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot.Model.Conversations

{
    public  class WeatherConversation
    {
        public static async Task StarWeatherUserDialogAsync(global::Telegram.Bot.Types.Message msg)
        {
            var step = 1;
            var userAnswer = new List<string>();
            int request = 0;

            var mre = new ManualResetEvent(false);

            EventHandler<MessageEventArgs> mHandler = (sender, e) =>
            {
                if (msg.From.Id != e.Message.From.Id) return;
                if (msg.Chat.Id != e.Message.Chat.Id) return;

                //if (step == 1)
                //{
                //    userAnswer.Add(e.Message.Text);
                //    step++;
                //    Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, $"Какую погоду ды хочешь узнать?", replyMarkup: Bot.GetButtons(new string[] { "Сейчас", "Hourly Forecast 4 days", "Daily Forecast 16 days" }));
                //    //Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, $"Nice! How old are you, {e.Message.Text}?");
                //}
                else if (step == 1)
                {
                    if (e.Message.Text == "Сейчас")
                    {
                        userAnswer.Add(e.Message.Text);
                        step++;
                        request = 1;
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: null);
                    } else if (e.Message.Text == "Hourly Forecast 4 days")
                    {
                        userAnswer.Add(e.Message.Text);
                        step++;
                        request = 4;
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: null);

                    } else if (e.Message.Text == "Daily Forecast 16 days")
                    {
                        userAnswer.Add(e.Message.Text);
                        step++;
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "В каком городе?", replyMarkup: null);
                        request = 16;
                    } 
                    else
                    {
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "Нажми на кнопку!");
                        return;
                    }
                    //if (e.Message.Text.IsInt())
                    //{
                    //    userInfos.Add(e.Message.Text);
                    //    step++;
                    //    Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "Where do you live?");
                    //}
                    //else
                    //{
                    //    Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "Only numbers are allowed!");
                    //    return;
                    //}
                }
                else if (step == 2)
                {
                    if (!string.IsNullOrEmpty(e.Message.Text))
                    {
                        userAnswer.Add(e.Message.Text);
                        step++;
                        var weather = new WeatherInCity(e.Message.Text, request);
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, weather.WeatherAnswer(),replyMarkup: Bot.GetButtons());
                    }
                    else
                    {
                        userAnswer.Add(e.Message.Text);
                        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, "Я все еще жду город?");
                    } 
                }
            //    else if (step == 3)
            //    {
            //        userAnswer.Add(e.Message.Text);
            //        Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, $"Okay! Your entered informations:\n\nYour Name: *{userAnswer.ElementAt(0)}*\nYour Age: *{userAnswer.ElementAt(1)}*\nYou live in: *{userAnswer.ElementAt(2)}*\nHelpful example? *{userAnswer.ElementAt(3)}*", ParseMode.Markdown);
            //    }
            };
            await Bot.GetClient().SendTextMessageAsync(msg.Chat.Id, $"Какую погоду ды хочешь узнать?", replyMarkup: Bot.GetButtons(new string[] { "Сейчас", "Hourly Forecast 4 days", "Daily Forecast 16 days" }));
            Bot.GetClient().OnMessage += mHandler;
            mre.WaitOne();
            Bot.GetClient().OnMessage -= mHandler;
        }
    }

    public static class ListStringExtensions
    {
        public static string GetRandom(this List<string> list)
        {
            var max = list.Count;
            var rnd = new Random();
            var rndNmb = rnd.Next(0, max);
            return list[rndNmb];
        }

        public static bool IsInt(this string s)
        {
            var x = 0;
            return int.TryParse(s, out x);
        }

    }
}
