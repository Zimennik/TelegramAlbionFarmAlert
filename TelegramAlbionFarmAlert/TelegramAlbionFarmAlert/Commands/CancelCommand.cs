using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramAlbionFarmAlert.Commands
{
    public class CancelCommand : Command
    {
        public override bool IsSystem => true;

        public CancelCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            if (args.User?.CurrentCommand != null)
            {
                var currentCommandName = args.User.CurrentCommand.Name;

                args.User.CurrentCommand = null;
                await args.Bot.SendTextMessageAsync(args.User.Id, $"Команда {currentCommandName} успешно отменена!",
                    ParseMode.Default, false, false, 0,
                    new ReplyKeyboardRemove());
            }
        }
    }
}
