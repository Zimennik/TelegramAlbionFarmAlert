using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramAlbionFarmAlert.Helper
{
    public static class ButtonRenderer
    {
        public static InlineKeyboardMarkup DrawMarkupButtons(Dictionary<string, string> buttons, byte columnCount = 1)
        {
            if (columnCount < 1)
                throw new ArgumentException("кол-во не может быть < 1!");

            var count = (int) Math.Ceiling((double) buttons.Count / columnCount);
            
            var result = new InlineKeyboardMarkup
            {
                InlineKeyboard = new InlineKeyboardButton[count][]
            };
            for (int i = 0; i < count; i++)
            {
                result.InlineKeyboard[i] = buttons
                    .Skip(i * columnCount)
                    .Take(columnCount)
                    .Select(x => new InlineKeyboardCallbackButton(x.Key, x.Value))
                    .ToArray();

            }
            return result;
        }
    }
}
