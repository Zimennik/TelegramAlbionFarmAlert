using System;
using System.Collections.ObjectModel;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public class CommandManager
    {
        public ObservableCollection<Command> ActiveCommands { get; }
        private static readonly object Lock = new object();

        public CommandManager()
        {
            ActiveCommands = new ObservableCollection<Command>();
        }

        public void Add(Command command)
        {
            command.OnComplete += Command_OnComplete;
            lock (Lock)
            {
                ActiveCommands.Add(command);
            }

        }

        private void Command_OnComplete(object sender, EventArgs e)
        {
            lock (Lock)
            {
                ActiveCommands.Remove(sender as Command);
            }
        }
    }
}
