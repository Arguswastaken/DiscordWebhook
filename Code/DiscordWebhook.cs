using System;
using System.Collections.Specialized;
using System.Net;

namespace DiscordWebhook
{
    public static class DiscordWebhook
    {
        public static WebClient web = new WebClient();

        public struct Request
        {
            public string content;
            public string username;
            public string avatar_url;
            public Uri url;

            public Request(string _content, string _username, string _avatar, string _url)
            {
                content = _content;
                username = _username;
                avatar_url = _avatar;
                try
                {
                    url = new Uri(_url);
                }
                catch (System.UriFormatException e)
                {
                    Host.Print($"URI assignment failed: UriFormatException ({e.Message})", ConsoleColor.Red);
                    url = null;
                    Exit();
                }
            }
        }

        public static void Execute(Request data)
        {
            if (string.IsNullOrWhiteSpace(data.content))
            {
                Host.Print("Request failed: No message content provided", ConsoleColor.Yellow);
                return;
            }

            if (data.url == null)
            {
                Host.Print($"Request failed: Invalid URI", ConsoleColor.Red);
                Exit();
            }

            NameValueCollection nvc = new NameValueCollection
            {
                {
                    "content", data.content
                },
                {
                    "username", data.username
                },
                {
                    "avatar_url", data.avatar_url
                }
            };

            nvc = FilterNVC(
                ref nvc,
                data.username != null,
                data.avatar_url != null
            );

            try
            {
                web.UploadValues(data.url, nvc);
                Host.Print("Request sent\n", ConsoleColor.Green);
            }
            catch (WebException e)
            {
                Host.Print($"Request failed: WebException ({e.Message})", ConsoleColor.Red);
            }
        }

        public static NameValueCollection FilterNVC(ref NameValueCollection _nvc, bool username, bool avatar)
        {
            NameValueCollection newNVC = _nvc;

            if (!username)
                newNVC.Remove("username");
            if (!avatar)
                newNVC.Remove("avatar_url");

            return newNVC;
        }

        static void Exit() => Host.Shutdown();
    }
}
