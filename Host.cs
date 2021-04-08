using System;

namespace DiscordWebhook
{
    class Host
    {
        static string username;
        static string avatar;
        static string url;

        static void Main()
        {
            SetWebhookData();
            for (; ; )
            {
                CallRequest(Console.ReadLine());
            }
        }

        static void SetWebhookData()
        {
            Console.WriteLine("Please enter a valid webhook URL.");
            string input = Console.ReadLine();
            url = input == "" ? null : input;

            Console.WriteLine("\nPlease enter a valid webhook username. Leave blank to use default.");
            input = Console.ReadLine();
            username = input == "" ? null : input;

            Console.WriteLine("\nPlease enter an avatar URL. Leave blank to use default.");
            input = Console.ReadLine();
            avatar = input == "" ? null : input;

            Console.Clear();
        }

        static void CallRequest(string content)
        {
            DiscordWebhook.Request request = new DiscordWebhook.Request(content, username, avatar, url);
            DiscordWebhook.Execute(request);
        }

        public static void Print(string text, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void Shutdown()
        {
            Print("Press any key to exit.", ConsoleColor.Red);
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}