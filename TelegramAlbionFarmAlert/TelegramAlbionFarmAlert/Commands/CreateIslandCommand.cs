using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramAlbionFarmAlert.Commands
{
    public class CreateIslandCommand : Command
    {
        public CreateIslandCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            await args.Bot.SendTextMessageAsync(args.User.Id, "Введите название острова");
        }

        public override async Task InputExecuteAsync(CommandArgs args)
        {
            await args.Bot.SendTextMessageAsync(args.User.Id, args.UserTextInput);

            await EndExecuteAsync(args);
        }
    }
}
