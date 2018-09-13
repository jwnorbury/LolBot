using Newtonsoft.Json;
using System;
using System.IO;

namespace MatchUpBot.Config
{
    public static class ConfigProvider
    {
        private const string CONFIG_FILE_NAME = "config.json";
        private static Config _config;
        public static Config Current
        {
            get
            {
                if (_config == null)
                {
                    _config = Load();
                }
                return _config;
            }
        }

        public static void Initialise() => _config = Load();

        private static Config Load()
        {
            var configFile = Directory.GetCurrentDirectory() + "\\" + CONFIG_FILE_NAME;
            if (!File.Exists(configFile))
            {
                throw new FileNotFoundException($"{CONFIG_FILE_NAME} missing from current directory");
            }
            using (var fs = new FileStream(configFile, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                var content = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<Config>(content);
            }
        }
    }
}
