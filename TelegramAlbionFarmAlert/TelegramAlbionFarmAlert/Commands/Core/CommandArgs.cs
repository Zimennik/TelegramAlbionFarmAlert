using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public class CommandArgs
    {
        public TelegramBotClient Bot { get; }
        public CustomUser User { get; }
        public string UserTextInput { get; set; }

        public CommandArgs(string userTextInput, TelegramBotClient bot, CustomUser user)
        {
            Bot = bot;
            User = user;
            UserTextInput = userTextInput;
        }
    }
}
