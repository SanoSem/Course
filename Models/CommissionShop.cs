using System;
using System.Collections.Generic;

namespace Сursova.Models
{
    public class CommissionShop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactInfo { get; set; }
        public string Notes { get; set; }

        // Навігаційна властивість для предметів у магазині (опціонально, можна завантажувати окремо)
        [Newtonsoft.Json.JsonIgnore] 
        public List<CommissionShopItem> Items { get; set; } = new List<CommissionShopItem>();
    }
}