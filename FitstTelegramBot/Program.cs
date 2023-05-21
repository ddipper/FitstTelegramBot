using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace FirstTelegramBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TelegramBotClient("[ENTER_BOT_API_KEY]");
            client.StartReceiving(Update, Error);
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var message = update.Message;
            if(message.Text != null)
            {
                Console.WriteLine($"FN: {message.Chat.FirstName ?? "NotNameSr"}, UN: {message.Chat.Username}, Say:  {message.Text}");
                if(message.Text.ToLower().Contains("привет"))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Привет девушка");
                    return;
                }
            }
            if(message.Photo != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Отличное фото, но лучше отправь мне его документом");
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}

