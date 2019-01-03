using System;
using System.Reflection;
using System.Threading.Tasks;

using System.IO;

using Discord;
using Discord.WebSocket;
using Discord.Commands;

namespace TestDiscordBot
{
    class Program
    {
        private DiscordSocketClient Client;
        private CommandService Commands;


        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();

        private async Task MainAsync()
        {
            Client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Debug });

            Commands = new CommandService(new CommandServiceConfig {CaseSensitiveCommands = true,  DefaultRunMode = RunMode.Async, LogLevel = LogSeverity.Debug});

            Client.MessageReceived += Client_messageReceived;
            await Commands.AddModulesAsync(Assembly.GetEntryAssembly());

            Client.Ready += Client_ready;
            Client.Log += Client_log;

            string loginToken = "Secret token";

                await Client.LoginAsync(TokenType.Bot, loginToken);
                await Client.LoginAsync(TokenType.Bot, loginToken);
                await Client.StartAsync();
                await Task.Delay(-1);
        }


        private async Task Client_ready()
        {
            await Client.SetGameAsync("with itself!", "https://www.google.com", StreamType.NotStreaming);
        }
        private async Task Client_log(LogMessage Message)
        {
            Console.WriteLine($"{DateTime.Now} at {Message.Source}] {Message.Message}");
        }

        private async Task Client_messageReceived(SocketMessage MessageParam)
        {
            SocketUserMessage Message = MessageParam as SocketUserMessage;
            SocketCommandContext Context = new SocketCommandContext(Client, Message);

            if(Context.Message == null || Context.Message.Content == "") return;
            if (Context.User.IsBot) return;

            int argPos = 0;
            if (!(Message.HasStringPrefix("I!", ref argPos) || Message.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;

            var result = await Commands.ExecuteAsync(Context, argPos);
            if (!result.IsSuccess) Console.WriteLine($"{DateTime.Now} at Commands] Oopsie woopsie uwu we made a fucky! Text: {Context.Message.Content} | Error: {result.ErrorReason}");

            //throw new NotImplementedException();
        }
    }
}
