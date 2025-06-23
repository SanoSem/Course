using System.Collections.Generic;
using System.ComponentModel;

namespace Сursova.Models
{
    public enum CollectorType
    {
        [Description("Приватний колекціонер")]
        PrivateCollector,
        [Description("Галерея")]
        Gallery,
        [Description("Музей")]
        Museum,
        [Description("Комісійний магазин")]
        ConsignmentShop
    }

    public class Collector
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public CollectorType Type { get; set; }
        public decimal? CollectionValue { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}