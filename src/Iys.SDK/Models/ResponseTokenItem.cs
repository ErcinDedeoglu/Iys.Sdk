using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class ResponseTokenItem
    {
        [JsonProperty("access_token")] public string AccessToken { get; set; }

        [JsonProperty("expires_in")] public string ExpiresIn { get; set; }

        [JsonProperty("refresh_token")] public string RefreshToken { get; set; }

        [JsonProperty("refresh_expires_in")] public string RefreshExpiresIn { get; set; }
    }
}