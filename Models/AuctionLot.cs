using System.ComponentModel;

namespace Сursova.Models
{
    public class AuctionLot
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Auction Auction { get; set; } // Для навігації
        public int PaintingId { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Painting Painting { get; set; } // Для навігації до картини
        public int LotNumber { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public bool IsSold { get; set; }
        public string BuyerInfo { get; set; } = string.Empty;
    }
}