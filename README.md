# DiscordWebhook
DiscordWebhook is a lightweight C# console application built on the .NET Framework for interacting with Discord webhooks using System.Net.

## Design & Usage
The program's entry point is contained in the `Host` class which also implements `SetWebhookData()` and `CallRequest()`. `SetWebhookData()` is called immediately by the `Main()` method at runtime, and allows the user to input a webhook URL, username and avatar URL. Input does not have to be provided for the latter two, and if it is left blank Discord will simply use the defaults attached to the webhook's integration.

After making these inputs, the user can send web requests to the specified URL at will just by typing messages and pressing enter. Success will be indicated by the message "Request sent" written in green. The program will report any other errors that occur when attempting to send a request, and will terminate the program if they are fatal.

## Purpose
The main reason I wrote this was to educate myself on webhooks and web requests, and the workings of a program that handles them. I figured I could publish it after I was done for anyone else who wants to learn about it themselves. As such it's not meant to see use in any important services or applications, so I couldn't really be bothered to implement complex behaviour to rectify issues on the spot. That's why I chose not to go out of my way to filter white space input everywhere, and the reason I just made the program quit after encountering an exception instead of properly handling and resetting it.

In any case, I hope you find this useful.
