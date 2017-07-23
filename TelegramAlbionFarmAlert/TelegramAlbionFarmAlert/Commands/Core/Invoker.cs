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

            var currentCommand = _command.FirstOrDefault(x => x.Name == args.Name);


            if (currentCommand == null)
                throw new NotSupportedException($"Комманда '{args.Name}' не найдена!");

            await currentCommand.StartExecuteAsync(args);
        }

        public static Invoker Create()
        {
            var invoker = new Invoker();

            invoker.SetCommand(new HelpCommand("/help", false));
            //invoker.SetCommand(new HelpCommand("/start", false));

            return invoker;
        }
    }
}
