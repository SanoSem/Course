using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Сursova.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public string AuctionHouse { get; set; } = string.Empty;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<AuctionLot> Lots { get; set; } = new List<AuctionLot>();
    }
}