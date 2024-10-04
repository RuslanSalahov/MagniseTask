using System;

namespace MagniseTask.Models
{
    public class PriceInfo
    {
        public string Id { get; set; }
        public string AssetId { get; set; }   // Asset identifier
        public decimal Price { get; set; }    // Latest price
        public DateTime LastUpdated { get; set; }  // Time of last update
    }
}
