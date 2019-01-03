using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;


namespace TestDiscordBot.Core.Commands
{

    public class compliments : ModuleBase<SocketCommandContext>
    {

        [Group("compliment"), Summary("For being nice to people!")]
        public class complimentGroup : ModuleBase<SocketCommandContext>
        {
            [Group("edit"), Summary("For being nice to people!")]
            public class complimentEditGroup : ModuleBase<SocketCommandContext>
            {
                [Group("description"), Alias("desc"), Summary("For being nice to people!")]
                public class complimentEditDescriptions : ModuleBase<SocketCommandContext>
                {
                    List<string> listDescriptions = new List<string>();
                    string Desc = "Descriptions";
                    // Descriptions
                    [Command("add")]
                    public async Task addDesc([Remainder] string message)
                    {
                        // add descriptions to list of usable descriptions
                        try
                        {
                            listDescriptions = Serializer.Load<List<string>>(Desc);
                            listDescriptions.Add(message);
                            Serializer.Save<List<string>>(Desc, listDescriptions);

                            await Context.Channel.SendMessageAsync($"ADDED Description: {message} Descriptions now has: {listDescriptions.Count} nice things in it!");
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"Error Adding Description: {message} Error Message: {e}");
                        }
                    }
                    [Command("remove")]
                    public async Task removeDesc([Remainder] string message)
                    {
                        // remove descriptions from list of usable descriptions
                        try
                        {
                            listDescriptions = Serializer.Load<List<string>>(Desc);
                            listDescriptions.Remove(message);
                            Serializer.Save<List<string>>(Desc, listDescriptions);

                            await Context.Channel.SendMessageAsync($"REMOVED Description: {message}. Descriptions now has: {listDescriptions.Count} nice things in it!");
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"Error Removing Description: {message} Error Message: {e}");
                        }
                    }
                }

                [Group("feature"), Alias("feat"), Summary("For being nice to people!")]
                public class complimentEditFeatures : ModuleBase<SocketCommandContext>
                {
                    List<string> listFeatures = new List<string>();
                    string Feat = "Features";

                    // Descriptions
                    [Command("add")]
                    public async Task addFeat([Remainder] string message)
                    {

                        // add features to list of usable descriptions
                        try
                        {
                            listFeatures = Serializer.Load<List<string>>(Feat);
                            listFeatures.Add(message);
                            Serializer.Save<List<string>>(Feat, listFeatures);

                            await Context.Channel.SendMessageAsync($"ADDED Feature: {message}. Features now has: {listFeatures.Count} nice things in it!");
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"Error Adding Feature: {message} Error Message: {e}");
                        }
                    }
                    [Command("remove")]
                    public async Task removeFeat([Remainder] string message)
                    {

                        // remove descriptions from list of usable descriptions
                        try
                        {
                            listFeatures = Serializer.Load<List<string>>(Feat);
                            listFeatures.Remove(message);
                            Serializer.Save<List<string>>(Feat, listFeatures);

                            await Context.Channel.SendMessageAsync($"REMOVED Feature: {message}. Features now has: {listFeatures.Count} nice things in it!");
                        }
                        catch (Exception e)
                        {
                            await Context.Channel.SendMessageAsync($"Error Removing Feature: {message} Error Message: {e}");
                        }
                    }
                }
            }
            [Command("get")]
            public async Task domenow()
            {
                // returns a random description and feature
                if(Context.User.Id == 122475291439398920) await Context.Channel.SendMessageAsync("ugly face");
                //else await Context.Channel.SendMessageAsync("beautiful penis");

                Random rand = new Random();
                await Context.Channel.SendMessageAsync($"Generated compliment: {getDesc(rand)} {getFeat(rand)}!");
            }
            string getDesc(Random rand)
            {
                string Desc;

                List<string> Descriptions = Serializer.Load<List<string>>("Descriptions");
                if (Descriptions.Count > 0)
                {
                    int randInt = rand.Next(0, Descriptions.Count);

                    Desc = Descriptions[randInt];
                }
                else Desc = "ERROR - No Descriptions found";

                return Desc;
            }
            string getFeat(Random rand)
            {
                string Feat;

                List<string> Features = Serializer.Load<List<string>>("Features");
                if (Features.Count > 0)
                {
                    int randInt = rand.Next(0, Features.Count);

                    Feat = Features[randInt];
                }
                else Feat = "ERROR - No Features found";

                return Feat;
            }

            System.Threading.Timer timer;

            [Command("schedule", RunMode = RunMode.Async)]
            public async Task scheduleCompliment([Remainder] string message)
            {
                await Context.Channel.SendMessageAsync($"Scheduling Compliment message for {Context.User} at(Hours:Minutes:Seconds): {message} from now!");

                try
                {
                    Console.WriteLine($"Scheduling event {message} from now");
        
                    string[] timeArray = message.Split(':');
                    double hours = Convert.ToDouble(timeArray[0]);
                    double mins = Convert.ToDouble(timeArray[1]);
                    double secs = Convert.ToDouble(timeArray[2]);

                    Console.WriteLine($"Event converted into timeArray: {timeArray}");

                    await Context.Channel.SendMessageAsync($"Scheduled Compliment in {hours} hours, {mins} mins, and {secs} seconds!");

                    double ms = (hours * 3600000) + (mins * 60000) + (secs * 1000);

                    Console.WriteLine($"Event converted into timeArray: {timeArray}");
                    //delaying responderino
                    await Task.Delay(Convert.ToInt32(ms)); //hours mins seconds

                    //late response
                    await scheduledMessage();

                }
                catch
                {
                    await Context.Channel.SendMessageAsync($"Error creating scheduled event at {message} perhaps wrong format was used? or maybe the lengh of time was too far away? I don't know, don't ask me I am just stupid bot!");
                }
            }
            async Task scheduledMessage()
            {
                Random rand = new Random();
                await Context.Channel.SendMessageAsync($"Scheduled compliment: {getDesc(rand)} {getFeat(rand)}!");
            }
        }
    }
}
