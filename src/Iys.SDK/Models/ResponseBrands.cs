using System.Collections.Generic;

namespace Iys.SDK.Models
{
    public class ResponseBrands
    {
        public List<BrandModel> List { get; set; }

        public ErrorWrapper Errors { get; set; }
    }
}