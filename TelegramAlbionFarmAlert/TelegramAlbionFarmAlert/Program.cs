using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotApp.Startup;

namespace TelegramAlbionFarmAlert
{
    class Program
    {
        static void Main(string[] args)
        {
            ITelegramBotManager bot = new TelegramBotCoreManager("449408095:AAHAcj1CbOtf8SjVVq0gZ3ZwB4SXMSCLn0g");
            bot.Start();

            Console.ReadLine();
        }
    }
}
