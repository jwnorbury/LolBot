using MatchUpBot.Config;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MatchUpBot
{
    internal class Program
    {
        static Program() => ConfigProvider.Initialise();
        
        private static void Main(string[] args) =>
            MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            Console.WriteLine(ConfigProvider.Current.Token);
            await Task.Delay(-1);
        }
    }
}
