using System;
using Telegram.Bot;

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

        
        }
    }
}
