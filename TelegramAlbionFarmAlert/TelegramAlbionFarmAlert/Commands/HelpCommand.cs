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
            var helpCommand = new Dictionary<string, string>
            {
                {"список островов", CommandNames.GetIslands},
                {"создать остров", CommandNames.CreateIsland},
                {"удалить остров", "/delete_island"},
                {"создать таймер", "/create_timer"},
                {"удалить таймер", "/delete_timer"},
                {"список таймеров", "/get_timers_list"}
                
            };
            await args.Bot.SendTextMessageAsync(args.User.Id, "Список доступных команд", ParseMode.Markdown, false, false,
                0, ButtonRenderer.DrawMarkupButtons(helpCommand, 2));
           
        }

    }
}
