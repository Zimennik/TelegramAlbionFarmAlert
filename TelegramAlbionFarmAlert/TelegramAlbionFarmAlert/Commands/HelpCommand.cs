using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramAlbionFarmAlert.Commands.Core;
using TelegramAlbionFarmAlert.Helper;

namespace TelegramAlbionFarmAlert.Commands
{
    public class HelpCommand : Command
    {
        public HelpCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            var test = new Dictionary<string, string>();
            test.Add("test", "/test");
            test.Add("test2", "/test2");
            test.Add("test3", "/test3");
            test.Add("test4", "/test4");
            test.Add("test5", "/test4");
            test.Add("test6", "/test4");
            test.Add("test7", "/test4");
            test.Add("test8", "/test4");
            test.Add("test9", "/test4");
            test.Add("test0", "/test4");
            test.Add("test10", "/test4");
            test.Add("test11", "/test4");
            test.Add("test12", "/test4");
            await args.Bot.SendTextMessageAsync(args.User.Id, "test", ParseMode.Markdown, false, false,
                0, ButtonRenderer.DrawMarkupButtons(test,5));
           
        }

    }
}
