using System;

namespace Сursova.Models
{
    public class CollectionItem
    {
        public int Id { get; set; }
        public int PaintingId { get; set; }
        public Painting Painting { get; set; }
        public bool IsOriginal { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public decimal? AcquisitionPrice { get; set; }
        public string Condition { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}