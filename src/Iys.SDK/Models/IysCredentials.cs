using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IysCredentials
    {
        [JsonProperty("username")] public string Username { get; set; }

        [JsonProperty("password")] public string Password { get; set; }

        [JsonProperty("grant_type")] public string GrantType { get; set; } = "password";
    }
}