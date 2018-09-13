using Newtonsoft.Json;

namespace MatchUpBot.Config
{
    public class Config
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
    }
}
