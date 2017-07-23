using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public class CommandArgs
    {
        public TelegramBotClient Bot { get; }
        public User User { get; }
        public string Name { get; set; }

        public CommandArgs(string name, TelegramBotClient bot, User user)
        {
            Bot = bot;
            User = user;
            Name = name;
        }
    }
}
