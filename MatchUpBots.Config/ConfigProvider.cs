using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MatchUpBot.Config
{
    public static class ConfigProvider
    {
        private const string CONFIG_FILE_NAME = "config.json";
        private static Config _config;

        private static string FilePath() =>
            Path.Combine(Directory.GetCurrentDirectory(), CONFIG_FILE_NAME);

        public static Config GetConfig()
        {
            if (_config == null)
            {
                _config = Load();
            }
            return _config;
        }

        public static async Task<Config> GetConfigAsync()
        {
            if (_config == null)
            {
                _config = await LoadAsync();
            }
            return _config;
        }

        private static void CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"{CONFIG_FILE_NAME} missing from current directory");
            }
        }

        private static async Task<Config> LoadAsync()
        {
            var filePath = FilePath();
            CheckFileExists(filePath);
            using (var fs = new FileStream(filePath, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                var content = await sr.ReadToEndAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<Config>(content);
            }
        }

        private static Config Load()
        {
            var filePath = FilePath();
            CheckFileExists(filePath);
            using (var fs = new FileStream(filePath, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                var content = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Config>(content);
            }
        }
    }
}
