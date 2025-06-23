using System;

namespace Сursova.Models
{
    public class PersonalCollectionItem
    {
        public int Id { get; set; }
        public int PaintingId { get; set; }
        public int? CollectorId { get; set; } // ID колекціонера або комісійного магазину

        public bool IsOriginal { get; set; }
        public decimal? PurchasePrice { get; set; } // Ціна придбання колекціонером або початкова ціна для комісійного магазину
        public DateTime PurchaseDate { get; set; } // Дата придбання колекціонером або дата виставлення для комісійного магазину
        public string PurchaseLocation { get; set; } = string.Empty;
        public decimal? CurrentValue { get; set; } // Поточна оціночна вартість або ціна, за яку виставлено в комісійному магазині
        public string Condition { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public bool IsSoldByConsignment { get; set; } // Чи продано через комісійний магазин
        public DateTime? SaleDate { get; set; } // Дата продажу
        public decimal? FinalSalePrice { get; set; } // Фінальна ціна продажу

        // Навігаційні властивості (для зручності доступу до пов'язаних об'єктів)
        public Painting Painting { get; set; }
        public Collector Collector { get; set; }
    }
}