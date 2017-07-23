using Telegram.Bot.Types;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramAlbionFarmAlert
{
    public class CustomUser
    {
        public User CurrentUser { get; }
        public Command CurrentCommand { get; set; }

        public CustomUser(User user)
        {
            CurrentUser = user;
        }
    }
}
