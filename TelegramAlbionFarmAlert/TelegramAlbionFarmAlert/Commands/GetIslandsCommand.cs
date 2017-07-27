using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramAlbionFarmAlert.Commands.Core;
using TelegramAlbionFarmAlert.Db;

namespace TelegramAlbionFarmAlert.Commands
{
    public class GetIslandsCommand : Command
    {
        public GetIslandsCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            //await args.Bot.SendTextMessageAsync(args.User.Id, "Введите название острова");
            using (var db = new XmlDbProvider())
            {
                var ilds = db.GetIslands();

                string result = "Список островов: \n\n";


                foreach (var island in ilds)
                {
                    result += island.Name + "\n";
                }

                await args.Bot.SendTextMessageAsync(args.User.Id, result);
            }
        }
    }
}
