using Telegram.Bot.Types;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramAlbionFarmAlert
{
    public class CustomUser
    {
        private Command _currentCommand;
        private readonly User _currentUser;

        public int Id => _currentUser.Id;
        public string Username => _currentUser.Username;

        public Command CurrentCommand
        {
            get { return _currentCommand; }
            set
            {
                _currentCommand = value;

                if(_currentCommand != null)
                    _currentCommand.OnComplete += _currentCommand_OnComplete;
            }
        }

        private void _currentCommand_OnComplete(object sender, System.EventArgs e)
        {
            CurrentCommand = null;
        }

        public CustomUser(User user)
        {
            _currentUser = user;
        }
    }
}
