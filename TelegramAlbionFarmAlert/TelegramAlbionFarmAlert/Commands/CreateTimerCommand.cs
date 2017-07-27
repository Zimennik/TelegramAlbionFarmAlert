using System;
using System.Threading.Tasks;
using TelegramAlbionFarmAlert.Commands.Core;
using TelegramAlbionFarmAlert.Db;

namespace TelegramAlbionFarmAlert.Commands
{
    public class CreateTimerCommand : Command
    {
        private Guid _islandID;
        private Guid _cultureID;
        
        public CreateTimerCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            
            
            await args.Bot.SendTextMessageAsync(args.User.Id, "Выбирите остров");
        }

        public override async Task InputExecuteAsync(CommandArgs args)
        {

            using (var db = new XmlDbProvider())
            {
                db.AddIsland(args.UserTextInput);
                db.SaveChanges();
            }

            await EndExecuteAsync(args);
            await args.Bot.SendTextMessageAsync(args.User.Id, $"Остров {args.UserTextInput} успешно сохранен!");
        }


        public void SelectIsland()
        {
            
        }

        public void SelectCulture()
        {
            
        }
        
    }
}