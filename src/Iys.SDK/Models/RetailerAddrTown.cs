using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerAddrTown : RetailerAddr
    {
        [JsonProperty("city_code")] public string CityCode { get; set; }
    }
}