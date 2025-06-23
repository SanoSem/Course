using System;
using Newtonsoft.Json;

namespace Сursova.Models
{
    public class CommissionShopItem
    {
        public int Id { get; set; }
        public int PaintingId { get; set; }
        public int CommissionShopId { get; set; }
        public decimal AskingPrice { get; set; }
        public DateTime ListingDate { get; set; }
        public bool IsSold { get; set; }
        public decimal? SalePrice { get; set; }
        public DateTime? SaleDate { get; set; }
        public string Notes { get; set; }

        // Навігаційні властивості
        [JsonIgnore]
        public Painting Painting { get; set; }

        [JsonIgnore]
        public CommissionShop CommissionShop { get; set; }
    }
}