using System;
using System.Threading.Tasks;

namespace TelegramAlbionFarmAlert.Commands.Core
{
    public abstract class Command
    {
        private readonly bool _needCancel;

        public string Name { get; }
        public event EventHandler OnComplete;

        public virtual bool IsSystem => false;

        protected Command(string name, bool needCancel)
        {
            Name = name;
            _needCancel = needCancel;
        }

        protected abstract Task CoreStartExecuteAsync(CommandArgs args);

        protected virtual Task EndCoreExecuteAsync(CommandArgs args)
        {
            return Task.CompletedTask;
        }

        public async Task StartExecuteAsync(CommandArgs args)
        {
            try
            {
                await CoreStartExecuteAsync(args);
            }
            finally
            {
                if (!_needCancel)
                    await EndExecuteAsync(args);
            }
        }

        public virtual Task InputExecuteAsync(CommandArgs args)
        {
            return Task.CompletedTask;
        }

        public async Task EndExecuteAsync(CommandArgs args)
        {
            try
            {
                await EndCoreExecuteAsync(args);
                await args.Bot.SendTextMessageAsync(args.User.Id, $"Команда {Name} успешно завершена!");
            }
            finally
            {
                OnComplete?.Invoke(this, null);
            }

        }
    }
}
