using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TelegramBot
{
    class Program
    {

        private static string token = "";
        private static TelegramBotClient client;

        [Obsolete]
        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        [Obsolete]
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Полученное сообщение: {msg.Text}");
                switch (msg.Text)
                {
                    case "/start":
                        await client.SendTextMessageAsync(chatId: msg.Chat.Id, "отправь команду /info");
                        break;
                    case "/info":
                        await client.SendTextMessageAsync(chatId: msg.Chat.Id, "Sticker:\n-TharelkaPig\n-TharelkaG\nGitHub: https://github.com/Tharelka/TharelkaBot-Telegram");
                        break;
                    case "TharelkaPig":
                        await client.SendStickerAsync(chatId: msg.Chat.Id, "https://raw.githubusercontent.com/Tharelka/TharelkaBot-Telegram/main/TharelkaPack/TharelkaPig.webp");
                        break;
                    case "TharelkaG":
                        await client.SendStickerAsync(chatId: msg.Chat.Id, "https://raw.githubusercontent.com/Tharelka/TharelkaBot-Telegram/main/TharelkaPack/TharelkaG.webp");
                        break;
                }
            }
        }
    }
}
