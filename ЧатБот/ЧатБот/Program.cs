using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
//using Telegram.Bot.Types.InlineKeyboardsButtons;
using ApiAiSDK;
using ApiAiSDK.Model;
using System.Net;
using System.Device.Location;


namespace ЧатБот
{
    class Program
    {
        static TelegramBotClient Bot;
        static ApiAi apiAi;
        static void Main(string[] args)
        {
            //31a2ca9d102741bca65837a1a32d8de5
            Bot = new TelegramBotClient("603120155:AAHX0VxPdcf8E90T54_fRzS4QhjRVoHUdTQ");
            AIConfiguration config = new AIConfiguration("31a2ca9d102741bca65837a1a32d8de5", SupportedLanguage.Russian);
            apiAi = new ApiAi(config);



            WebClient wc = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            //return wc.DownloadString(string.Format(ApiUrl, type));


            //apiAi = new ApiAi("31a2ca9d102741bca65837a1a32d8de5");

            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;

            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);
            //Console.WriteLine("Test");

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static async void BotOnCallbackQueryReceived(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            //throw new NotImplementedException();
            string buttonText = e.CallbackQuery.Data;
            string name = $"{e.CallbackQuery.From.FirstName} {e.CallbackQuery.From.LastName}";
            Console.WriteLine($"{name} push button {buttonText}");
            try
            {
                await Bot.AnswerCallbackQueryAsync(e.CallbackQuery.Id, $"You are selected the button {buttonText}");
                
            }
            catch
            {
            }
        }

        private static async void BotOnMessageReceived(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            //throw new NotImplementedException();
            var message = e.Message;

            if (message.Location == null)
                return;
            else
                Console.WriteLine($"Location:  Latitude='{message.Location.Latitude}'; Longitude='{message.Location.Longitude}'");

            //Double sLatitude = message.Location.Latitude;
            //Double sLongitude = message.Location.Longitude;
            //Double eLatitude = 50.43907;
            //Double eLongitude = 30.52336;


                var sCoord = new GeoCoordinate(message.Location.Latitude, message.Location.Longitude);
                var eCoord = new GeoCoordinate(50.41796545749433, 30.392232222207426);
            //50.41796545749433, 30.392232222207426 Ashan
            //50.43907, 30.52336 gulliver

            Console.WriteLine($"Distance = '{sCoord.GetDistanceTo(eCoord)}'");
            await Bot.SendTextMessageAsync(message.From.Id, $"Select some one '{sCoord.GetDistanceTo(eCoord)}'");

            if (message == null || message.Type != MessageType.Text || message.Location == null)
                return;
            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} отправил сообщение: '{message.Text}'");
            //Console.WriteLine($"{name} Location:  Latitude='{message.Location.Latitude}'; Longitude='{message.Location.Longitude}'");
            

            switch (message.Text)
            {
                //case "/start":
                //    string text =
                //             @"Список команд:
                //            /start - запуск бота
                //            /callback - вывод меню
                //            /keyboard - вывод клавиатуры";
                //    await Bot.SendTextMessageAsync(message.From.Id, text);
                //    break;
                case "/start":
                    var inlinekeyboard = new InlineKeyboardMarkup(new[]
                    {
                        //new[]
                        //{
                        //    InlineKeyboardButton.WithUrl("Site","http://google.com.ua"),
                        //    InlineKeyboardButton.WithUrl("Telegram","https://t.me")
                        //},
                        new[]
                        {
                             InlineKeyboardButton.WithCallbackData("\U0001F4B3 Моя карта"),
                             InlineKeyboardButton.WithCallbackData("\U0001F52D Найти магазин")
                         },
                        new[]{
                             InlineKeyboardButton.WithCallbackData("\U0001F464 Профиль"),
                             InlineKeyboardButton.WithCallbackData("\U0001F45C История покупок")
                        },
                        new[]{
                             InlineKeyboardButton.WithCallbackData("\U0001F4DD Заказы"), //memo //package
                             InlineKeyboardButton.WithCallbackData("\U0001F4B0 Корзина")
                        },
                        new[]{
                             InlineKeyboardButton.WithCallbackData("\U0001F516 Просмотры"),
                             InlineKeyboardButton.WithUrl("Eldorado","Eldorado.ua")
                             
                         


                             //right-pointing magnifying glass
                             //package
                             //telescope U+1F52D
                             //
                            //InlineKeyboardButton.WithSwitchInlineQuery("Найти магаз", A )  
                             

                        }
                         
                             
                        
                    });




                    await Bot.SendTextMessageAsync(message.From.Id, "Select some one", replyMarkup: inlinekeyboard);
                    break;
                case "/keyboard":
                    var replyKeyboard = new ReplyKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            new KeyboardButton("Hello"),
                            new KeyboardButton("How are you?")
                        },
                        new[]
                        {
                            new KeyboardButton("Contact") { RequestContact = true},
                            new KeyboardButton("Geolocation") { RequestLocation = true}
                        }
                    });
                    await Bot.SendTextMessageAsync(message.Chat.Id, "Message for keyboard", replyMarkup: replyKeyboard);
                   // await Bot.SendTextMessageAsync(message.Chat.Id, "ddjdj" + message.Location.Longitude);  //[message.location.longitude, message.location.latitude].join(";"));

                    break;
                default:
                    var response = apiAi.TextRequest(message.Text);
                    string answer = response.Result.Fulfillment.Speech;
                    if (answer == "")
                        answer = "Соррян! Я тебя не понял.";
                    await Bot.SendTextMessageAsync(message.From.Id, answer);
                    break;

            }
        }
    }
}
