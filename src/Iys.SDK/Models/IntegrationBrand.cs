using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class IntegrationBrand
    {
        [JsonProperty("brandCode")] public string BrandCode { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("master")] public bool Master { get; set; }

        [JsonProperty("agreementControl")] public bool AgreementControl { get; set; }

        [JsonProperty("MESAJ")] public string Sms { get; set; }

        [JsonProperty("ARAMA")] public string Call { get; set; }

        [JsonProperty("EPOSTA")] public string Email { get; set; }
    }
}