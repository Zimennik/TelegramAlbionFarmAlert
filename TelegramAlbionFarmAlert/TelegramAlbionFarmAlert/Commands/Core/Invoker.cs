using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public class Invoker
    {
        private readonly IList<Command> _command;

        public Invoker()
        {
            _command = new List<Command>();
        }

        public void SetCommand(Command command)
        {
            _command.Add(command);
        }

        public async Task ExecuteCommandAsync(CommandArgs args)
        {
            if (args == null)
                throw new ArgumentException("Аргементы команды не указаны!");

            var currentCommand = _command.FirstOrDefault(x => x.Name == args.UserTextInput);
            
            if (currentCommand == null)
                throw new NotSupportedException($"Комманда '{args.UserTextInput}' не найдена!");

            if(!currentCommand.IsSystem)
                args.User.CurrentCommand = currentCommand;

            await currentCommand.StartExecuteAsync(args);
        }

        public async Task ExecuteCommandArgsAsync(CommandArgs args)
        {
            if (args == null)
                throw new ArgumentException("Аргементы команды не указаны!");

            if (args.User.CurrentCommand == null)
            {
                throw new ArgumentException("Команда не запущена!");
            }

            await args.User.CurrentCommand.InputExecuteAsync(args);
        }

        public static Invoker Create()
        {
            var invoker = new Invoker();

            invoker.SetCommand(new HelpCommand(CommandNames.Help, false));
            invoker.SetCommand(new CreateIslandCommand(CommandNames.CreateIsland, true));
            invoker.SetCommand(new CancelCommand(CommandNames.Cancel, false));
            invoker.SetCommand(new GetIslandsCommand(CommandNames.GetIslands, false));

            return invoker;
        }
    }
}
