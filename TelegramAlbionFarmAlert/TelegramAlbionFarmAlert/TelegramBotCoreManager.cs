using System;
using System.Net;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAlbionFarmAlert.Commands.Core;

namespace TelegramAlbionFarmAlert
{
    public class TelegramBotCoreManager : ITelegramBotManager
    {
        private readonly TelegramBotClient _bot;
        private readonly UserManager _users;

        private readonly Invoker _invoker;

        public TelegramBotCoreManager(string token)
        {
            _bot = new TelegramBotClient(token, new WebProxy());
            _users = new UserManager();

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
                _users.ConnectUser(user);

                var currentUser = _users.FindUser(user);

                if (currentUser == null)
                    throw new ArgumentException($"User {user.Username} not found");

                if (textData.StartsWith("/"))
                {
                    if (currentUser.CurrentCommand == null || textData.StartsWith(CommandNames.Cancel))
                    {
                        await _invoker.ExecuteCommandAsync(new CommandArgs(textData, _bot, currentUser));
                    }
                    else
                    {
                        await _bot.SendTextMessageAsync(user.Id,
                            $"комманда {currentUser.CurrentCommand?.Name ?? "(NULL)"} запущена, отмените её /cancel");
                    }
                }
                else
                {
                    await _invoker.ExecuteCommandArgsAsync(new CommandArgs(textData, _bot, currentUser));
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
