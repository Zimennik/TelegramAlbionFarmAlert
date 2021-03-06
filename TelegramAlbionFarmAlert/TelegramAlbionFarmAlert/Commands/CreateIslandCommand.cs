﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramAlbionFarmAlert.Commands.Core;
using TelegramAlbionFarmAlert.Db;

namespace TelegramAlbionFarmAlert.Commands
{
    public class CreateIslandCommand : Command
    {
        public CreateIslandCommand(string name, bool needCancel) : base(name, needCancel)
        {
        }

        protected override async Task CoreStartExecuteAsync(CommandArgs args)
        {
            await args.Bot.SendTextMessageAsync(args.User.Id, "Введите название острова");
        }

        public override async Task InputExecuteAsync(CommandArgs args)
        {
            //todo save

            using (var db = new XmlDbProvider())
            {
                db.AddIsland(args.UserTextInput);
                db.SaveChanges();
            }

            await EndExecuteAsync(args);
            await args.Bot.SendTextMessageAsync(args.User.Id, $"Остров {args.UserTextInput} успешно сохранен!");
        }
    }
}
