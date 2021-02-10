﻿using Newtonsoft.Json;

namespace Iys.SDK.Models
{
    public class RetailerConsentItem
    {
        [JsonProperty("retailerCode")] public int RetailerCode { get; set; }

        [JsonProperty("tckn")] public string Tckn { get; set; }

        [JsonProperty("mersis")] public string Mersis { get; set; }

        [JsonProperty("mobile")] public string Mobile { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("alias")] public string Alias { get; set; }

        [JsonProperty("city")] public RetailerAddr City { get; set; }

        [JsonProperty("town")] public RetailerAddr Town { get; set; }
    }
}