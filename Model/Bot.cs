using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramMyFirstBot.Model.Commands
{
    public static class Bot
    {
        public static List<WeatherRequestFromUser> userRequests = new List<WeatherRequestFromUser>();
        public static TelegramBotClient Client { get; private set; }
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        private static void UserRequestAndCleaner ()
        {
            userRequests = userRequests.Where(x => x.Step != -1).ToList();
        }
        private static void LogMessage(MessageEventArgs incomingMessage) 
        {
            Console.WriteLine($"[log]: Пришло сообщение типа {incomingMessage.Message.Type} от : {incomingMessage.Message.From.FirstName} с текстом {incomingMessage.Message.Text}");
        }
        public static async void OnMessageHandler(object sender, MessageEventArgs incoming)
        {
            LogMessage(incoming);
            //ActionPhoto action = new ActionPhoto();
            ////if (incoming.Message.Type== Telegram.Bot.Types.Enums.MessageType.Photo)
            //{
            //    action.ExecuteAsync(incoming.Message, Bot.Client);
            //}
            if (incoming.Message.Text == null || incoming.Message.Text == string.Empty)
                return;
            //try
            //{
                foreach (var command in commandsList)
                {
                    if (command.Contains(incoming.Message.Text.ToLower()))
                    {
                        command.Execute(incoming.Message, Client);
                        break;
                    }
                }
                if (userRequests.Count != 0)
                {
                    foreach(var temp in userRequests)
                    {
                      await temp.WeatherUserDialogAsync(incoming.Message);
                    }
                    UserRequestAndCleaner();
                }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("[err]Возникло исключение сообщение боту"+e.Message +e.ToString());
            //}
        }

        public static IReplyMarkup ReturnStartSetOfButtons()
        {
            
            return new ReplyKeyboardMarkup(
               new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Привет" }, new KeyboardButton { Text = "/Погода" }},
                    new List<KeyboardButton> { new KeyboardButton { Text = "Стикер" }, new KeyboardButton { Text = "Картинка" }}
                }, true, true);
        }
        public static IReplyMarkup ReturnSetOfButtonsInlineWithTextParam(string[] buttonText)
        {

            InlineKeyboardButton[] keyboardButton =new InlineKeyboardButton[buttonText.Length];
            int i = 0;
            foreach (var temp in buttonText)
            {
                keyboardButton [i] = (InlineKeyboardButton)temp;
               // keyboardButton [i] = temp;
                i++;
            }
            InlineKeyboardMarkup keyboardMarkup = (InlineKeyboardMarkup)keyboardButton ;
            return keyboardMarkup;

            //Получив Telegram.Bot.Types.Message с этим объектом, клиенты Telegram
            //// отобразит интерфейс ответа пользователю (действует так, как если бы пользователь выбрал
            //// сообщение бота и нажал «Ответить»). Это может быть чрезвычайно полезно, если вы хотите
            //// создание удобных пошаговых интерфейсов без ущерба для конфиденциальности
            ////     Режим.
            //ForceReplyMarkup;

          //  По желанию. Используйте этот параметр, если хотите показать клавиатуру определенным пользователям.
          // Только. Цели: 1) пользователи, @ упомянутые в тексте объекта Description;
          // 2) если сообщение бота является ответом (имеет Telegram.Bot.Types.Message.ReplyToMessage),
          // отправитель исходного сообщения. Пример: пользователь просит изменить бота
          // язык, бот отвечает на запрос с помощью клавиатуры, чтобы выбрать новый язык.
          // Другие пользователи в группе не видят клавиатуру.
            //ReplyMarkupBase
            //replymarkup = $telegram->replyKeyboardHide();
        }
        public static void Init()
        {
            Client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            var me = Client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());
            commandsList.Add(new WeatherCommand());
            commandsList.Add(new StickerCommand());
            commandsList.Add(new ImageCommand());

            //TODO: Add more commands

            //JObject jObject = JObject.Parse(jsonText);
            //Dictionary<string, List<Order>> dict =
            //    jObject.ToObject<Dictionary<string, List<Order>>>();

            //Dictionary<string, List<Order>> JsonObject = JsonConvert.DeserializeObject<Dictionary<string, List<Order>>>(jsonText);
            //List<string> Json_Array = JsonConvert.DeserializeObject<List<string>>(jsonText);
            //string a= "{\"coord\":{\"lon\":61.4297,\"lat\":55.1544},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03n\"}],\"base\":\"stations\",\"main\":{\"temp\":20.05,\"feels_like\":20.02,\"temp_min\":20.05,\"temp_max\":20.05,\"pressure\":1013,\"humidity\":73},\"visibility\":10000,\"wind\":{\"speed\":0,\"deg\":0},\"clouds\":{\"all\":40},\"dt\":1628017984,\"sys\":{\"type\":1,\"id\":8975,\"country\":\"RU\",\"sunrise\":1628035661,\"sunset\":1628092381},\"timezone\":18000,\"id\":1508291,\"name\":\"Челябинск\",\"cod\":200}";
        }
    }
}
