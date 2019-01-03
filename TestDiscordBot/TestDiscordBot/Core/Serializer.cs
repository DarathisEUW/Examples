using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace TestDiscordBot.Core
{
    class Serializer
    {
        public static T Load<T>(string filename) where T : class
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = new FileStream(filePath(filename), FileMode.Open))
                {
                    Console.WriteLine($"Loading file: {filename} From: {file}");
                    return bf.Deserialize(file) as T;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading file: {filename} Could not find! Replacing with empty string list");
                //return default(T);
                //New cannot load list so returns a new list for saving
                List<string> newList = new List<string>();
                return newList as T;
            }
        }

        public static void Save<T>(string filename, T data) where T : class
        {
            //Create Directory if it does not exist
            if (!Directory.Exists(Path.GetDirectoryName(filePath(filename))))
            {
                Console.WriteLine($"Creating file: {filename} To: {filePath(filename)}");
                Directory.CreateDirectory(Path.GetDirectoryName(filePath(filename)));
            }
            Console.WriteLine($"File: {filename} Exists at: {filePath(filename)}");

            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream file = new FileStream(filePath(filename), FileMode.Create))
                {
                    bf.Serialize(file, data);
                    Console.WriteLine($"Saving file: {filename} To: {file}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving file: {filename} Error Code: {e}");
            }
        }

        public static string filePath(string fileName)
        {
            //string filePath = "C:\Users\Harry\Desktop\Dev\DevProjects\DiscordBots\TestDiscordBot\TestDiscordBot\Data\Saving"
            string filePath = System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory());
            //System.IO.Directory.GetCurrentDirectory();
            filePath = Path.Combine(filePath + "\\Saving\\", fileName + ".txt");
            Console.WriteLine($"Filepath: {filePath}");

            return filePath;
        }
    }
}
