using System;

namespace DiscordWebhook
{
    public sealed class Host
    {
        public static string username;
        public static string avatar;
        public static string url;

        public static void Main()
        {
            SetWebhookData();
            for (; ; )
            {
                CallRequest(Console.ReadLine());
            }
        }

        private static void SetWebhookData()
        {
            AssignVariable("Please enter a valid webhook URL.", ref url);
            AssignVariable("Please enter a valid webhook username. Leave blank to use default.", ref username);
            AssignVariable("Please enter an avatar URL. Leave blank to use default.", ref avatar);

            Console.Clear();

            Console.WriteLine("Webhook data set. You may now begin sending requests.\n" +
                "[e.g. \"Cookies\" will send a request containing the content \"Cookies\".]\n");
        }

        private static void AssignVariable(string prompt, ref string variable)
        {
            Print(prompt, ConsoleColor.Green);

            string input = Console.ReadLine();
            variable = string.IsNullOrWhiteSpace(input) ? null : input;

            Console.WriteLine();
        }

        private static void CallRequest(string content)
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