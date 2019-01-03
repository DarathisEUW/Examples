using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace TestDiscordBot.Core.Commands
{
    public class HelloWorld : ModuleBase<SocketCommandContext>
    {
        [Command("hello"), Alias("helloworld"), Summary("Hello world command")]
        public async Task callCommand()
        {
            await Context.Channel.SendMessageAsync("Hello World");
        }
    }
}
