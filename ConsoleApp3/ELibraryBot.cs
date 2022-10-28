using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ConsoleApp3
{
    internal class ELibraryBot
    {
        public ELibraryBot(string token)
        {
            ITelegramBotClient bot = new TelegramBotClient(token);
            //Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать в нашу библиотеку, добрый читатель!");
                    return;
                }
                if (message.Text.ToLower() == "найти книгу")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите фильтр", replyMarkup: FiltrButtons());
                    return;
                }
                if (message.Text.ToLower() == "автор")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "", replyMarkup: FiltrButtons());
                    return;
                }
                if (message.Text.ToLower() == "жанр")
                {
                    //await botClient.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать на борт, добрый путник!");
                    return;
                }
                if (message.Text.ToLower() == "название")
                {
                    //await botClient.SendTextMessageAsync(message.Chat.Id, "Добро пожаловать на борт, добрый путник!");
                    return;
                }
                if (message.Text.ToLower() == "вернуться")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите фильтр", replyMarkup: FiltrButtons());
                    return;
                }
                await botClient.SendTextMessageAsync(message.Chat.Id, "Выберите другое действие", replyMarkup: FindBook());
                //await botClient.SendTextMessageAsync(message.Chat, "Привет-привет!!");
            }
        }

        private static IReplyMarkup GetButtons()
        {
            var markup = new ReplyKeyboardMarkup(keyboard: new List<List<KeyboardButton>>
            {
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.GENRE), new KeyboardButton(ClassLibrary1.Model.Constants.GENRE) },
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.GENRE), new KeyboardButton(ClassLibrary1.Model.Constants.GENRE) }
            });
            //markup.OneTimeKeyboard = true;
            return markup;
        }

        private static IReplyMarkup FindBook()
        {
            var markup = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton(ClassLibrary1.Model.Constants.FINDBOOK)
            });
            markup.ResizeKeyboard = true;
            return markup;
        }

        private static IReplyMarkup FiltrButtons()
        {
            var markup = new ReplyKeyboardMarkup(keyboard: new List<List<KeyboardButton>>
            {
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.NAME) },
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.AUTHOR) },
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.GENRE) },
                new List<KeyboardButton>{ new KeyboardButton(ClassLibrary1.Model.Constants.RETURN) }
            });
            //markup.OneTimeKeyboard = true;
            markup.ResizeKeyboard = true;
            return markup;
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
