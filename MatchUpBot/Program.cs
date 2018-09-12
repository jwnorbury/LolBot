using System;
using System.Threading.Tasks;

namespace MatchUpBot
{
    public class Program
    {
        public static void Main(string[] args)
            => MainAsync().GetAwaiter().GetResult();

        private static async Task MainAsync()
        {
            await Task.Delay(-1);
        }
    }
}
