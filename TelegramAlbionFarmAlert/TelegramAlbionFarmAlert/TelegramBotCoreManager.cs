using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using TelegramAlbionFarmAlert;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramBotApp.Startup
{
    public class TelegramBotCoreManager : ITelegramBotManager
    {
        private readonly TelegramBotClient _bot;

        private readonly Invoker _invoker;

        public TelegramBotCoreManager(string token)
        {
            _bot = new TelegramBotClient(token, new WebProxy());

            _bot.OnMessage += _bot_OnMessage;
            _bot.OnCallbackQuery += _bot_OnCallbackQuery;

            _invoker = Invoker.Create();
        }

        private async void _bot_OnCallbackQuery(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            await RetriveMessage(e.CallbackQuery.From, e.CallbackQuery.Data);
        }

        private async void _bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            await RetriveMessage(e.Message.From, e.Message.Text);
        }

        private async Task RetriveMessage(User user, string textData)
        {
            try
            {
                if (textData.StartsWith("/"))
                {
                    await _invoker.ExecuteCommandAsync(new CommandArgs(textData, _bot, user));
                }
            }
            catch (NotSupportedException ex)
            {
                await _bot.SendTextMessageAsync(user.Id, $"Ошибка, команда {textData} не найдена.");
            }
            catch (Exception ex)
            {
                await _bot.SendTextMessageAsync(user.Id, $"Упс, чт-то пошло не так\n{ex.Message}");
            }
        }

        public void Start()
        {
            try
            {
                if (_bot.IsReceiving)
                {
                    return;
                }

                _bot.StartReceiving();
            }
            catch (Exception ex)
            {
                // todo что делать при ошибке старта бота?
            }
        }

        public void Stop()
        {
            try
            {
                _bot.StopReceiving();
            }
            catch (Exception ex)
            {
                // todo что делать при ошибке остановки бота?
            }
        }
    }
}
