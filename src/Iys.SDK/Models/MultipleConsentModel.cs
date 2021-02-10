using System.Collections.Generic;

namespace Iys.SDK.Models
{
    public class MultipleConsentModel
    {
        public int BrandCode { get; set; }

        public string Source { get; set; }

        public string RecipientType { get; set; }

        public string Type { get; set; }

        public int? RetailerCode { get; set; }

        public List<int> RetailerAccess { get; set; }

        public List<MultipleConsentItem> List { get; set; }

        public string Base64File { get; set; }
    }
}