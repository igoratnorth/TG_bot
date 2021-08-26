using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TG_bot
{
    class Program
    {
        public static ITelegramBotClient tg_client_test1;
        static void Main(string[] args)
        {
            tg_client_test1 = new TelegramBotClient("1999658156:AAHqszUUXtrxL3CayPYUS119rpUXPIZTwQs") { Timeout= TimeSpan.FromSeconds(10)};
            var inst1 = tg_client_test1.GetMeAsync().Result;
            Console.WriteLine($"id:{ inst1.Id} name:{inst1.Username}");
            tg_client_test1.OnMessage += Handler_OnMassage;
            tg_client_test1.StartReceiving();
            Console.ReadKey();
        }

        private static void Handler_OnMassage(object sender, MessageEventArgs e)
        {
            var text = e?.Message;
            var text2 = e?.Message?.Text;
            Console.WriteLine("отладочка");
            Console.WriteLine($"e.masage '{text}' e.massage.text '{text2}' \n Info: '{e.Message.From}' ,  '{e.Message.Chat.Id}', '{e.Message.Contact}'");

        }
    }
}
