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

            var result = new InlineKeyboardMarkup { InlineKeyboard = new InlineKeyboardButton[buttons.Count / columnCount][] };
            for (int i = 0; i < buttons.Count / columnCount; i++)
            {
                result.InlineKeyboard[i] = buttons
                    .Take(columnCount)
                    .Skip(i * columnCount)
                    .Select(x => new InlineKeyboardCallbackButton(x.Key, x.Value))
                    .ToArray();

            }
            return result;
        }
    }
}
