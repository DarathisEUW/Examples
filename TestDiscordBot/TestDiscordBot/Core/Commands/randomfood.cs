using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace TestDiscordBot.Core.Commands
{
    public class randomfood : ModuleBase<SocketCommandContext>
    {
        [Group("food"), Summary("For getting random dinners!")]
        public class foodGroup : ModuleBase<SocketCommandContext>
        {
            List<string> foodsList = new List<string>();
            string foods = "FoodsList";

            [Group("edit"), Summary("For editing random dinners lists!")]
            public class foodEditGroup : ModuleBase<SocketCommandContext>
            {

                List<string> foodsList = new List<string>();
                string foods = "FoodsList";

                [Command("add")]
                public async Task addFood([Remainder] string message)
                {
                    await Context.Channel.SendMessageAsync($"Adding food: {message} to list of foods!");

                    try
                    {
                        foodsList = Serializer.Load<List<string>>(foods);
                        foodsList.Add(message);
                        Serializer.Save<List<string>>(foods, foodsList);

                        await Context.Channel.SendMessageAsync($"ADDED Food: {message} Foods list now has: {foodsList.Count} nice things in it!");
                    }
                    catch (Exception e)
                    {
                        await Context.Channel.SendMessageAsync($"Error Adding Food: {message} Error Message: {e}");
                    }
                }
                [Command("remove")]
                public async Task removeFood([Remainder] string message)
                {
                    await Context.Channel.SendMessageAsync($"Removing food: {message} to list of foods!");

                    try
                    {
                        foodsList = Serializer.Load<List<string>>(foods);
                        foodsList.Remove(message);
                        Serializer.Save<List<string>>(foods, foodsList);

                        await Context.Channel.SendMessageAsync($"REMOVED Food: {message}. Foods list now has: {foodsList.Count} nice things in it!");
                    }
                    catch (Exception e)
                    {
                        await Context.Channel.SendMessageAsync($"Error Removing Food: {message} Error Message: {e}");
                    }
                }
            }
            [Command("get")]
            public async Task getFood()
            {
                List<string> foodsList = Serializer.Load<List<string>>(foods);

                Random rand = new Random();
                await Context.Channel.SendMessageAsync($"Random Food: {foodsList[rand.Next(0, foodsList.Count)]}");
            }

            [Command("list")]
            public async Task FoodsList()
            {
                List<string> foodsList = Serializer.Load<List<string>>(foods);
                EmbedBuilder embed = new EmbedBuilder();

                embed.Title = "All foods in List!";

                //embed.AddInlineField($"Food items: {foodsList.Count}", foodsList);
                for(int i = 0; i < foodsList.Count; i++)
                {
                    //embed.AddInlineField($"Food item: {i}", foodsList[i]);
                    embed.AddField($"Food item: {i + 1}", foodsList[i]);
                }

                await Context.Channel.SendMessageAsync("", false, embed);
            }



            [Command("help")]
            public async Task foodHelp()
            {
                List<string> foodsList = Serializer.Load<List<string>>(foods);
                EmbedBuilder embed = new EmbedBuilder();

                embed.Title = "List of commands for Foods! as of 11/07/2018";

                embed.AddField("Return single food item.", $"@InadequateBot#7645 food get");
                embed.AddField("Return list of all food items.", $"@InadequateBot#7645 food list");
                embed.AddField("Add food item to list.", $"@InadequateBot#7645 food edit add (food to add)");
                embed.AddField("Remove food item from list.", $"@InadequateBot#7645 food edit add (food to remove)");

                embed.AddField("Return this commands list.", $"@InadequateBot#7645 food help");

                await Context.Channel.SendMessageAsync("", false, embed);
            }
        }
    }
}
