using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace TestDiscordBot.Core.Commands
{
    public class parrot : ModuleBase<SocketCommandContext>
    {
        [Command("repeat"), Alias("parrot", "repeatafterme"), Summary("Parrots back message to user.")]
        public async Task parrotCommand([Remainder] string message)
        {
            string output;
            Random random = new Random();
            int responseType = random.Next(0, 10);

            if (responseType == 0) output = sarcasm(message);
            else if (responseType == 1) output = shouting(message);
            else output = message;

            await Context.Channel.SendMessageAsync(output);

        }
        // 1/10 to be super mad and shout message back
        string shouting(string input)
        {
            string message = input;
            message = message.ToUpper();
            return message;
        }
        // 1/10 to be snarky and sArCaStIc In ReSpOnSe
        string sarcasm(string input)
        {
            string output = "";

            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0) output += char.ToLower(input[i]);
                else output += char.ToUpper(input[i]);
            }
            return output;
        }
     }
}
