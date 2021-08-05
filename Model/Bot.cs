﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramMyFirstBot.Model.Commands;

namespace TelegramMyFirstBot.Model.Commands
{
    public static class Bot
    {
        //static string jsonText = "{\"cod\":\"200\",\"message\":0,\"cnt\":40,\"list\":[{\"dt\":1628024400,\"main\":{\"temp\":19.84,\"feels_like\":19.76,\"temp_min\":19.42,\"temp_max\":19.84,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":988,\"humidity\":72,\"temp_kf\":0.42},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"clouds\":{\"all\":54},\"wind\":{\"speed\":1.03,\"deg\":182,\"gust\":1.15},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-03 21:00:00\"},{\"dt\":1628035200,\"main\":{\"temp\":19.02,\"feels_like\":18.91,\"temp_min\":18.5,\"temp_max\":19.02,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":988,\"humidity\":74,\"temp_kf\":0.52},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"clouds\":{\"all\":63},\"wind\":{\"speed\":0.79,\"deg\":205,\"gust\":1.06},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-04 00:00:00\"},{\"dt\":1628046000,\"main\":{\"temp\":22.75,\"feels_like\":22.65,\"temp_min\":22.75,\"temp_max\":22.75,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":988,\"humidity\":60,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":26},\"wind\":{\"speed\":1.57,\"deg\":121,\"gust\":1.76},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-04 03:00:00\"},{\"dt\":1628056800,\"main\":{\"temp\":28.44,\"feels_like\":28.14,\"temp_min\":28.44,\"temp_max\":28.44,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":988,\"humidity\":41,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":35},\"wind\":{\"speed\":2.09,\"deg\":169,\"gust\":2.12},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-04 06:00:00\"},{\"dt\":1628067600,\"main\":{\"temp\":31.99,\"feels_like\":30.92,\"temp_min\":31.99,\"temp_max\":31.99,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":988,\"humidity\":31,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"небольшая облачность\",\"icon\":\"02d\"}],\"clouds\":{\"all\":17},\"wind\":{\"speed\":1.44,\"deg\":176,\"gust\":2},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-04 09:00:00\"},{\"dt\":1628078400,\"main\":{\"temp\":32.88,\"feels_like\":31.47,\"temp_min\":32.88,\"temp_max\":32.88,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":27,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"небольшая облачность\",\"icon\":\"02d\"}],\"clouds\":{\"all\":12},\"wind\":{\"speed\":1.12,\"deg\":101,\"gust\":2.66},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-04 12:00:00\"},{\"dt\":1628089200,\"main\":{\"temp\":27.32,\"feels_like\":27.66,\"temp_min\":27.32,\"temp_max\":27.32,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":987,\"humidity\":49,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":9},\"wind\":{\"speed\":3.17,\"deg\":116,\"gust\":5.48},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-04 15:00:00\"},{\"dt\":1628100000,\"main\":{\"temp\":22.23,\"feels_like\":22.31,\"temp_min\":22.23,\"temp_max\":22.23,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":988,\"humidity\":69,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"небольшой дождь\",\"icon\":\"10n\"}],\"clouds\":{\"all\":23},\"wind\":{\"speed\":5.17,\"deg\":250,\"gust\":10.65},\"visibility\":10000,\"pop\":0.33,\"rain\":{\"3h\":0.48},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-04 18:00:00\"},{\"dt\":1628110800,\"main\":{\"temp\":20.73,\"feels_like\":20.71,\"temp_min\":20.73,\"temp_max\":20.73,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":985,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"clouds\":{\"all\":82},\"wind\":{\"speed\":1.23,\"deg\":124,\"gust\":1.7},\"visibility\":10000,\"pop\":0.19,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-04 21:00:00\"},{\"dt\":1628121600,\"main\":{\"temp\":19.16,\"feels_like\":18.99,\"temp_min\":19.16,\"temp_max\":19.16,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":986,\"humidity\":71,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"пасмурно\",\"icon\":\"04n\"}],\"clouds\":{\"all\":87},\"wind\":{\"speed\":2.66,\"deg\":229,\"gust\":4.3},\"visibility\":10000,\"pop\":0.11,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-05 00:00:00\"},{\"dt\":1628132400,\"main\":{\"temp\":22.99,\"feels_like\":22.83,\"temp_min\":22.99,\"temp_max\":22.99,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":986,\"humidity\":57,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":67},\"wind\":{\"speed\":2.67,\"deg\":230,\"gust\":4.99},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-05 03:00:00\"},{\"dt\":1628143200,\"main\":{\"temp\":29.3,\"feels_like\":28.82,\"temp_min\":29.3,\"temp_max\":29.3,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":985,\"humidity\":39,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":54},\"wind\":{\"speed\":2.41,\"deg\":205,\"gust\":3.14},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-05 06:00:00\"},{\"dt\":1628154000,\"main\":{\"temp\":33.05,\"feels_like\":32.06,\"temp_min\":33.05,\"temp_max\":33.05,\"pressure\":1008,\"sea_level\":1008,\"grnd_level\":984,\"humidity\":30,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":55},\"wind\":{\"speed\":3.71,\"deg\":177,\"gust\":3.96},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-05 09:00:00\"},{\"dt\":1628164800,\"main\":{\"temp\":34.06,\"feels_like\":32.88,\"temp_min\":34.06,\"temp_max\":34.06,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":983,\"humidity\":27,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":71},\"wind\":{\"speed\":3.7,\"deg\":176,\"gust\":4.97},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-05 12:00:00\"},{\"dt\":1628175600,\"main\":{\"temp\":28.88,\"feels_like\":28.76,\"temp_min\":28.88,\"temp_max\":28.88,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":982,\"humidity\":43,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":27},\"wind\":{\"speed\":1.19,\"deg\":245,\"gust\":3.31},\"visibility\":10000,\"pop\":0.02,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-05 15:00:00\"},{\"dt\":1628186400,\"main\":{\"temp\":21.24,\"feels_like\":21.51,\"temp_min\":21.24,\"temp_max\":21.24,\"pressure\":1009,\"sea_level\":1009,\"grnd_level\":983,\"humidity\":80,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"небольшой дождь\",\"icon\":\"10n\"}],\"clouds\":{\"all\":49},\"wind\":{\"speed\":6.07,\"deg\":232,\"gust\":9.94},\"visibility\":10000,\"pop\":0.62,\"rain\":{\"3h\":2.33},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-05 18:00:00\"},{\"dt\":1628197200,\"main\":{\"temp\":19.81,\"feels_like\":19.88,\"temp_min\":19.81,\"temp_max\":19.81,\"pressure\":1007,\"sea_level\":1007,\"grnd_level\":982,\"humidity\":78,\"temp_kf\":0},\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"небольшой дождь\",\"icon\":\"10n\"}],\"clouds\":{\"all\":100},\"wind\":{\"speed\":4.87,\"deg\":296,\"gust\":10.81},\"visibility\":10000,\"pop\":0.71,\"rain\":{\"3h\":2.71},\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-05 21:00:00\"},{\"dt\":1628208000,\"main\":{\"temp\":17.96,\"feels_like\":18.08,\"temp_min\":17.96,\"temp_max\":17.96,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":984,\"humidity\":87,\"temp_kf\":0},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"пасмурно\",\"icon\":\"04n\"}],\"clouds\":{\"all\":87},\"wind\":{\"speed\":2.07,\"deg\":290,\"gust\":4.76},\"visibility\":10000,\"pop\":0.64,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-06 00:00:00\"},{\"dt\":1628218800,\"main\":{\"temp\":19.67,\"feels_like\":19.68,\"temp_min\":19.67,\"temp_max\":19.67,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":984,\"humidity\":76,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":42},\"wind\":{\"speed\":5.08,\"deg\":319,\"gust\":7.89},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-06 03:00:00\"},{\"dt\":1628229600,\"main\":{\"temp\":21.54,\"feels_like\":21.37,\"temp_min\":21.54,\"temp_max\":21.54,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":986,\"humidity\":62,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":32},\"wind\":{\"speed\":6.37,\"deg\":308,\"gust\":7.5},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-06 06:00:00\"},{\"dt\":1628240400,\"main\":{\"temp\":24.45,\"feels_like\":24.23,\"temp_min\":24.45,\"temp_max\":24.45,\"pressure\":1011,\"sea_level\":1011,\"grnd_level\":986,\"humidity\":49,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":4},\"wind\":{\"speed\":6.06,\"deg\":305,\"gust\":7.11},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-06 09:00:00\"},{\"dt\":1628251200,\"main\":{\"temp\":25.44,\"feels_like\":25.14,\"temp_min\":25.44,\"temp_max\":25.44,\"pressure\":1010,\"sea_level\":1010,\"grnd_level\":985,\"humidity\":42,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":9},\"wind\":{\"speed\":5.16,\"deg\":300,\"gust\":5.54},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-06 12:00:00\"},{\"dt\":1628262000,\"main\":{\"temp\":21.36,\"feels_like\":21.17,\"temp_min\":21.36,\"temp_max\":21.36,\"pressure\":1012,\"sea_level\":1012,\"grnd_level\":986,\"humidity\":62,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":43},\"wind\":{\"speed\":5.62,\"deg\":334,\"gust\":9.23},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-06 15:00:00\"},{\"dt\":1628272800,\"main\":{\"temp\":17.01,\"feels_like\":16.99,\"temp_min\":17.01,\"temp_max\":17.01,\"pressure\":1013,\"sea_level\":1013,\"grnd_level\":987,\"humidity\":85,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"небольшая облачность\",\"icon\":\"02n\"}],\"clouds\":{\"all\":22},\"wind\":{\"speed\":4.7,\"deg\":338,\"gust\":9.7},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-06 18:00:00\"},{\"dt\":1628283600,\"main\":{\"temp\":15.27,\"feels_like\":15.18,\"temp_min\":15.27,\"temp_max\":15.27,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":988,\"humidity\":89,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03n\"}],\"clouds\":{\"all\":50},\"wind\":{\"speed\":3.98,\"deg\":319,\"gust\":9.06},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-06 21:00:00\"},{\"dt\":1628294400,\"main\":{\"temp\":14.84,\"feels_like\":14.42,\"temp_min\":14.84,\"temp_max\":14.84,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":988,\"humidity\":78,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04n\"}],\"clouds\":{\"all\":74},\"wind\":{\"speed\":4.11,\"deg\":315,\"gust\":9.41},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-07 00:00:00\"},{\"dt\":1628305200,\"main\":{\"temp\":17.41,\"feels_like\":16.83,\"temp_min\":17.41,\"temp_max\":17.41,\"pressure\":1015,\"sea_level\":1015,\"grnd_level\":989,\"humidity\":62,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":49},\"wind\":{\"speed\":5.5,\"deg\":323,\"gust\":9.38},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-07 03:00:00\"},{\"dt\":1628316000,\"main\":{\"temp\":20.98,\"feels_like\":20.28,\"temp_min\":20.98,\"temp_max\":20.98,\"pressure\":1015,\"sea_level\":1015,\"grnd_level\":990,\"humidity\":44,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":70},\"wind\":{\"speed\":5.38,\"deg\":323,\"gust\":6.79},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-07 06:00:00\"},{\"dt\":1628326800,\"main\":{\"temp\":23.58,\"feels_like\":22.93,\"temp_min\":23.58,\"temp_max\":23.58,\"pressure\":1014,\"sea_level\":1014,\"grnd_level\":989,\"humidity\":36,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03d\"}],\"clouds\":{\"all\":38},\"wind\":{\"speed\":5.69,\"deg\":316,\"gust\":7.02},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-07 09:00:00\"},{\"dt\":1628337600,\"main\":{\"temp\":24.04,\"feels_like\":23.31,\"temp_min\":24.04,\"temp_max\":24.04,\"pressure\":1015,\"sea_level\":1015,\"grnd_level\":989,\"humidity\":31,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"небольшая облачность\",\"icon\":\"02d\"}],\"clouds\":{\"all\":24},\"wind\":{\"speed\":6.01,\"deg\":318,\"gust\":7.36},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-07 12:00:00\"},{\"dt\":1628348400,\"main\":{\"temp\":20.61,\"feels_like\":19.85,\"temp_min\":20.61,\"temp_max\":20.61,\"pressure\":1016,\"sea_level\":1016,\"grnd_level\":990,\"humidity\":43,\"temp_kf\":0},\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"облачно с прояснениями\",\"icon\":\"04d\"}],\"clouds\":{\"all\":61},\"wind\":{\"speed\":5.3,\"deg\":306,\"gust\":9.16},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-07 15:00:00\"},{\"dt\":1628359200,\"main\":{\"temp\":16.8,\"feels_like\":16.05,\"temp_min\":16.8,\"temp_max\":16.8,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":991,\"humidity\":58,\"temp_kf\":0},\"weather\":[{\"id\":802,\"main\":\"Clouds\",\"description\":\"переменная облачность\",\"icon\":\"03n\"}],\"clouds\":{\"all\":43},\"wind\":{\"speed\":4.64,\"deg\":316,\"gust\":10.38},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-07 18:00:00\"},{\"dt\":1628370000,\"main\":{\"temp\":14.65,\"feels_like\":13.82,\"temp_min\":14.65,\"temp_max\":14.65,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":991,\"humidity\":63,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01n\"}],\"clouds\":{\"all\":9},\"wind\":{\"speed\":4.1,\"deg\":320,\"gust\":9.94},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-07 21:00:00\"},{\"dt\":1628380800,\"main\":{\"temp\":12.85,\"feels_like\":11.94,\"temp_min\":12.85,\"temp_max\":12.85,\"pressure\":1018,\"sea_level\":1018,\"grnd_level\":992,\"humidity\":67,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01n\"}],\"clouds\":{\"all\":6},\"wind\":{\"speed\":3.86,\"deg\":315,\"gust\":9.27},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-08 00:00:00\"},{\"dt\":1628391600,\"main\":{\"temp\":15.91,\"feels_like\":14.94,\"temp_min\":15.91,\"temp_max\":15.91,\"pressure\":1019,\"sea_level\":1019,\"grnd_level\":993,\"humidity\":53,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":5.15,\"deg\":320,\"gust\":9.13},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-08 03:00:00\"},{\"dt\":1628402400,\"main\":{\"temp\":20.27,\"feels_like\":19.37,\"temp_min\":20.27,\"temp_max\":20.27,\"pressure\":1018,\"sea_level\":1018,\"grnd_level\":992,\"humidity\":39,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.01,\"deg\":317,\"gust\":8.72},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-08 06:00:00\"},{\"dt\":1628413200,\"main\":{\"temp\":23.19,\"feels_like\":22.4,\"temp_min\":23.19,\"temp_max\":23.19,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":992,\"humidity\":32,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":0},\"wind\":{\"speed\":6.38,\"deg\":320,\"gust\":8.56},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-08 09:00:00\"},{\"dt\":1628424000,\"main\":{\"temp\":23.66,\"feels_like\":22.86,\"temp_min\":23.66,\"temp_max\":23.66,\"pressure\":1017,\"sea_level\":1017,\"grnd_level\":992,\"humidity\":30,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":1},\"wind\":{\"speed\":6.41,\"deg\":323,\"gust\":8.15},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-08 12:00:00\"},{\"dt\":1628434800,\"main\":{\"temp\":19.87,\"feels_like\":18.93,\"temp_min\":19.87,\"temp_max\":19.87,\"pressure\":1018,\"sea_level\":1018,\"grnd_level\":992,\"humidity\":39,\"temp_kf\":0},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"ясно\",\"icon\":\"01d\"}],\"clouds\":{\"all\":2},\"wind\":{\"speed\":3.98,\"deg\":317,\"gust\":7.55},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"d\"},\"dt_txt\":\"2021-08-08 15:00:00\"},{\"dt\":1628445600,\"main\":{\"temp\":15.31,\"feels_like\":14.31,\"temp_min\":15.31,\"temp_max\":15.31,\"pressure\":1018,\"sea_level\":1018,\"grnd_level\":992,\"humidity\":54,\"temp_kf\":0},\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"небольшая облачность\",\"icon\":\"02n\"}],\"clouds\":{\"all\":13},\"wind\":{\"speed\":3.1,\"deg\":326,\"gust\":5.67},\"visibility\":10000,\"pop\":0,\"sys\":{\"pod\":\"n\"},\"dt_txt\":\"2021-08-08 18:00:00\"}],\"city\":{\"id\":1508291,\"name\":\"Челябинск\",\"coord\":{\"lat\":55.1544,\"lon\":61.4297},\"country\":\"RU\",\"population\":1062919,\"timezone\":18000,\"sunrise\":1628035661,\"sunset\":1628092381}}";
        public static TelegramBotClient Client { get; private set; }
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        private static void LogMessage(MessageEventArgs incomingMessage) 
        {
            Console.WriteLine($"[log]: Пришло сообщение типа {incomingMessage.Message.Type} от : {incomingMessage.Message.From.FirstName} с текстом {incomingMessage.Message.Text}");
        }
        public static async void OnMessageHandler(object sender, MessageEventArgs incoming)
        {
            LogMessage(incoming);
            if (incoming.Message.Text == null || incoming.Message.Text == string.Empty)
                return;
            try
            {
                foreach (var command in commandsList)
                {
                    if (command.Contains(incoming.Message.Text.ToLower()))
                    {
                        command.Execute(incoming.Message, Client);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("[err]Возникло исключение сообщение боту");
            }
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
        public static IReplyMarkup ReturnSetOfButtonsWithTextParam(string[] buttonText)
        {
            var buttonList = new List<KeyboardButton>();
            var keyboardMarkup = new ReplyKeyboardMarkup();
            foreach (var text in buttonText)
            {
                buttonList.Add(new KeyboardButton { Text = text });
            }
            keyboardMarkup.Keyboard = new List<List<KeyboardButton>> { buttonList };
            return keyboardMarkup;
        }
        public static void Init()
        {
            Client = new TelegramBotClient(AppSettings.Key) { Timeout = TimeSpan.FromSeconds(10) };
            var me = Client.GetMeAsync().Result;
            Console.WriteLine($"BotID: { me.Id}\n BotName:{me.FirstName}");
           // Bot.Client.ke ReplyKeyboardMarkup : Bot.ReturnStartSetOfButtons());
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
