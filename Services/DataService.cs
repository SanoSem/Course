using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Сursova.Models;

namespace Сursova.Services
{
    public class DataService
    {
        private readonly string _artistsFilePath;
        private readonly string _paintingsFilePath;
        private readonly string _auctionsFilePath;
        private readonly string _auctionLotsFilePath;
        private readonly string _collectorsFilePath;
        private readonly string _personalCollectionItemsFilePath;
        private readonly string _commissionShopsFilePath;
        private readonly string _commissionShopItemsFilePath;

        private readonly string _dataDirectory;

        public DataService()
        {
            _dataDirectory = Path.Combine(Application.StartupPath, "Data");
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }

            _artistsFilePath = Path.Combine(_dataDirectory, "Artists.json");
            _paintingsFilePath = Path.Combine(_dataDirectory, "Paintings.json");
            _auctionsFilePath = Path.Combine(_dataDirectory, "Auctions.json");
            _auctionLotsFilePath = Path.Combine(_dataDirectory, "AuctionLots.json");
            _collectorsFilePath = Path.Combine(_dataDirectory, "Collectors.json");
            _personalCollectionItemsFilePath = Path.Combine(_dataDirectory, "PersonalCollectionItems.json");
            _commissionShopsFilePath = Path.Combine(_dataDirectory, "CommissionShops.json"); // ДОДАНО
            _commissionShopItemsFilePath = Path.Combine(_dataDirectory, "CommissionShopItems.json"); // ДОДАНО

            InitializeJsonFiles();
        }

        private List<T> ReadFromJsonFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json) ?? new List<T>();
        }

        private void WriteToJsonFile<T>(string filePath, List<T> data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        private int GetNextId<T>(List<T> list) where T : class
        {
            if (list == null || !list.Any())
            {
                return 1;
            }
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty == null)
            {
                throw new InvalidOperationException($"Тип {typeof(T).Name} не містить властивості 'Id'.");
            }
            if (!list.Any())
            {
                return 1;
            }

            return list.Max(item => (int)idProperty.GetValue(item)) + 1;
        }


        private void InitializeJsonFiles()
        {
            if (!File.Exists(_artistsFilePath))
            {
                WriteToJsonFile(_artistsFilePath, new List<Artist>());
            }
            if (!File.Exists(_paintingsFilePath))
            {
                WriteToJsonFile(_paintingsFilePath, new List<Painting>());
            }
            if (!File.Exists(_auctionsFilePath))
            {
                WriteToJsonFile(_auctionsFilePath, new List<Auction>());
            }
            if (!File.Exists(_auctionLotsFilePath))
            {
                WriteToJsonFile(_auctionLotsFilePath, new List<AuctionLot>());
            }
            if (!File.Exists(_collectorsFilePath))
            {
                WriteToJsonFile(_collectorsFilePath, new List<Collector>());
            }
            if (!File.Exists(_personalCollectionItemsFilePath))
            {
                WriteToJsonFile(_personalCollectionItemsFilePath, new List<PersonalCollectionItem>());
            }
            if (!File.Exists(_commissionShopsFilePath)) 
            {
                WriteToJsonFile(_commissionShopsFilePath, new List<CommissionShop>()); 
            }
            if (!File.Exists(_commissionShopItemsFilePath)) 
            {
                WriteToJsonFile(_commissionShopItemsFilePath, new List<CommissionShopItem>()); 
            }
        }


        // Методи для Artist
        public List<Artist> GetAllArtists()
        {
            return ReadFromJsonFile<Artist>(_artistsFilePath);
        }

        public void SaveArtist(Artist artist)
        {
            List<Artist> artists = GetAllArtists();
            if (artist.Id == 0)
            {
                artist.Id = GetNextId(artists);
                artists.Add(artist);
            }
            else
            {
                var existingArtist = artists.FirstOrDefault(a => a.Id == artist.Id);
                if (existingArtist != null)
                {
                    existingArtist.FirstName = artist.FirstName;
                    existingArtist.LastName = artist.LastName;
                    existingArtist.BirthDate = artist.BirthDate;
                    existingArtist.DeathDate = artist.DeathDate;
                    existingArtist.Nationality = artist.Nationality;
                    existingArtist.Biography = artist.Biography;
                    existingArtist.Styles = artist.Styles;
                    existingArtist.PhotoPath = artist.PhotoPath;
                }
            }
            WriteToJsonFile(_artistsFilePath, artists);
        }

        public void DeleteArtist(int id)
        {
            List<Artist> artists = GetAllArtists();
            artists.RemoveAll(a => a.Id == id);
            WriteToJsonFile(_artistsFilePath, artists);
        }

        public Artist GetArtistById(int id)
        {
            return GetAllArtists().FirstOrDefault(a => a.Id == id);
        }


        // Методи для Painting
        public List<Painting> GetAllPaintings()
        {
            var paintings = ReadFromJsonFile<Painting>(_paintingsFilePath);
            var artists = GetAllArtists();

            foreach (var painting in paintings)
            {
                painting.Artist = artists.FirstOrDefault(a => a.Id == painting.ArtistId);
            }
            return paintings;
        }

        public void SavePainting(Painting painting)
        {
            List<Painting> paintings = GetAllPaintings();
            if (painting.Id == 0)
            {
                painting.Id = GetNextId(paintings);
                paintings.Add(painting);
            }
            else
            {
                var existingPainting = paintings.FirstOrDefault(p => p.Id == painting.Id);
                if (existingPainting != null)
                {
                    existingPainting.Title = painting.Title;
                    existingPainting.ArtistId = painting.ArtistId;
                    existingPainting.CreationDate = painting.CreationDate; 
                    existingPainting.Year = painting.Year;
                    existingPainting.Genre = painting.Genre;
                    existingPainting.Technique = painting.Technique;
                    existingPainting.Dimensions = painting.Dimensions;
                    existingPainting.Description = painting.Description;
                    existingPainting.ImagePath = painting.ImagePath;
                }
            }
            foreach (var p in paintings)
            {
                p.Artist = null;
            }
            WriteToJsonFile(_paintingsFilePath, paintings);
        }

        public void UpdatePainting(Painting painting)
        {
            SavePainting(painting);
        }

        public Painting GetPaintingById(int paintingId)
        {
            return GetAllPaintings().FirstOrDefault(p => p.Id == paintingId);
        }

        public void DeletePainting(int id)
        {
            List<Painting> paintings = GetAllPaintings();
            paintings.RemoveAll(p => p.Id == id);
            foreach (var p in paintings)
            {
                p.Artist = null;
            }
            WriteToJsonFile(_paintingsFilePath, paintings);
        }

        // Методи для Collector
        public List<Collector> GetAllCollectors()
        {
            return ReadFromJsonFile<Collector>(_collectorsFilePath);
        }

        public void SaveCollector(Collector collector)
        {
            List<Collector> collectors = GetAllCollectors();
            if (collector.Id == 0)
            {
                collector.Id = GetNextId(collectors);
                collectors.Add(collector);
            }
            else
            {
                var existingCollector = collectors.FirstOrDefault(c => c.Id == collector.Id);
                if (existingCollector != null)
                {
                    existingCollector.Name = collector.Name;
                    existingCollector.ContactInfo = collector.ContactInfo;
                    existingCollector.Address = collector.Address;
                    existingCollector.Type = collector.Type;
                    existingCollector.CollectionValue = collector.CollectionValue;
                    existingCollector.Notes = collector.Notes;
                }
            }
            WriteToJsonFile(_collectorsFilePath, collectors);
        }

        public void DeleteCollector(int id)
        {
            List<Collector> collectors = GetAllCollectors();
            collectors.RemoveAll(c => c.Id == id);
            WriteToJsonFile(_collectorsFilePath, collectors);

            DeletePersonalCollectionItemsByCollectorId(id);
        }

        public Collector GetCollectorById(int collectorId)
        {
            return GetAllCollectors().FirstOrDefault(c => c.Id == collectorId);
        }


        // Методи для PersonalCollectionItem
        public List<PersonalCollectionItem> GetAllPersonalCollectionItems()
        {
            var items = ReadFromJsonFile<PersonalCollectionItem>(_personalCollectionItemsFilePath);
            var paintings = GetAllPaintings(); 
            var collectors = GetAllCollectors();

            foreach (var item in items)
            {
                item.Painting = paintings.FirstOrDefault(p => p.Id == item.PaintingId);
                item.Collector = collectors.FirstOrDefault(c => c.Id == item.CollectorId);
            }
            return items;
        }

        public List<PersonalCollectionItem> GetPersonalCollectionItemsByCollectorId(int collectorId)
        {
            return GetAllPersonalCollectionItems().Where(item => item.CollectorId == collectorId).ToList();
        }

        public void SavePersonalCollectionItem(PersonalCollectionItem item)
        {
            List<PersonalCollectionItem> items = GetAllPersonalCollectionItems();
            if (item.Id == 0)
            {
                item.Id = GetNextId(items);
                items.Add(item);
            }
            else
            {
                var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    existingItem.PaintingId = item.PaintingId;
                    existingItem.IsOriginal = item.IsOriginal;
                    existingItem.PurchaseDate = item.PurchaseDate;
                    existingItem.PurchasePrice = item.PurchasePrice;
                    existingItem.PurchaseLocation = item.PurchaseLocation;
                    existingItem.CurrentValue = item.CurrentValue;
                    existingItem.Condition = item.Condition;
                    existingItem.StorageLocation = item.StorageLocation;
                    existingItem.Notes = item.Notes;
                }
            }
            foreach (var i in items)
            {
                i.Painting = null;
                i.Collector = null;
            }
            WriteToJsonFile(_personalCollectionItemsFilePath, items);
        }

        public void UpdatePersonalCollectionItem(PersonalCollectionItem item)
        {
            SavePersonalCollectionItem(item);
        }

        public void DeletePersonalCollectionItem(int id)
        {
            List<PersonalCollectionItem> items = GetAllPersonalCollectionItems();
            items.RemoveAll(i => i.Id == id);
            foreach (var i in items)
            {
                i.Painting = null;
                i.Collector = null;
            }
            WriteToJsonFile(_personalCollectionItemsFilePath, items);
        }

        public void DeletePersonalCollectionItemsByCollectorId(int collectorId)
        {
            List<PersonalCollectionItem> items = GetAllPersonalCollectionItems();
            items.RemoveAll(i => i.CollectorId == collectorId);
            foreach (var i in items)
            {
                i.Painting = null;
                i.Collector = null;
            }
            WriteToJsonFile(_personalCollectionItemsFilePath, items);
        }


        // Методи для Auction
        public List<Auction> GetAllAuctions()
        {
            return ReadFromJsonFile<Auction>(_auctionsFilePath);
        }

        public void SaveAuction(Auction auction)
        {
            List<Auction> auctions = GetAllAuctions();
            if (auction.Id == 0)
            {
                auction.Id = GetNextId(auctions);
                auctions.Add(auction);
            }
            else
            {
                var existingAuction = auctions.FirstOrDefault(a => a.Id == auction.Id);
                if (existingAuction != null)
                {
                    existingAuction.Name = auction.Name;
                    existingAuction.Date = auction.Date;
                    existingAuction.Location = auction.Location;
                    existingAuction.AuctionHouse = auction.AuctionHouse;
                }
            }
            WriteToJsonFile(_auctionsFilePath, auctions);
        }

        public void DeleteAuction(int id)
        {
            List<Auction> auctions = GetAllAuctions();
            auctions.RemoveAll(a => a.Id == id);
            WriteToJsonFile(_auctionsFilePath, auctions);

            DeleteAuctionLotsByAuctionId(id);
        }

        // Методи для AuctionLot
        public List<AuctionLot> GetAllAuctionLots()
        {
            var lots = ReadFromJsonFile<AuctionLot>(_auctionLotsFilePath);
            var paintings = GetAllPaintings();
            var auctions = GetAllAuctions();

            foreach (var lot in lots)
            {
                lot.Painting = paintings.FirstOrDefault(p => p.Id == lot.PaintingId);
                lot.Auction = auctions.FirstOrDefault(a => a.Id == lot.AuctionId);
            }
            return lots;
        }

        public void SaveAuctionLot(AuctionLot lot)
        {
            List<AuctionLot> lots = GetAllAuctionLots();
            if (lot.Id == 0)
            {
                lot.Id = GetNextId(lots);
                lots.Add(lot);
            }
            else
            {
                var existingLot = lots.FirstOrDefault(l => l.Id == lot.Id);
                if (existingLot != null)
                {
                    existingLot.AuctionId = lot.AuctionId;
                    existingLot.PaintingId = lot.PaintingId;
                    existingLot.LotNumber = lot.LotNumber;
                    existingLot.StartingPrice = lot.StartingPrice;
                    existingLot.FinalPrice = lot.FinalPrice;
                    existingLot.IsSold = lot.IsSold;
                    existingLot.BuyerInfo = lot.BuyerInfo;
                }
            }
            foreach (var l in lots)
            {
                l.Painting = null;
                l.Auction = null;
            }
            WriteToJsonFile(_auctionLotsFilePath, lots);
        }

        public void DeleteAuctionLot(int id)
        {
            List<AuctionLot> lots = GetAllAuctionLots();
            lots.RemoveAll(l => l.Id == id);
            foreach (var l in lots)
            {
                l.Painting = null;
                l.Auction = null;
            }
            WriteToJsonFile(_auctionLotsFilePath, lots);
        }

        public void DeleteAuctionLotsByAuctionId(int auctionId)
        {
            List<AuctionLot> lots = GetAllAuctionLots();
            lots.RemoveAll(l => l.AuctionId == auctionId);
            foreach (var l in lots)
            {
                l.Painting = null;
                l.Auction = null;
            }
            WriteToJsonFile(_auctionLotsFilePath, lots);
        }

        public List<AuctionLot> GetLotsForAuction(int auctionId)
        {
            List<AuctionLot> allLots = GetAllAuctionLots();
            List<AuctionLot> lotsForAuction = allLots.Where(lot => lot.AuctionId == auctionId).ToList();
            return lotsForAuction;
        }

        //  Методи для CommissionShop
        public List<CommissionShop> GetAllCommissionShops()
        {
            return ReadFromJsonFile<CommissionShop>(_commissionShopsFilePath);
        }

        public void SaveCommissionShop(CommissionShop shop)
        {
            List<CommissionShop> shops = GetAllCommissionShops();
            if (shop.Id == 0)
            {
                shop.Id = GetNextId(shops);
                shops.Add(shop);
            }
            else
            {
                var existingShop = shops.FirstOrDefault(s => s.Id == shop.Id);
                if (existingShop != null)
                {
                    existingShop.Name = shop.Name;
                    existingShop.Address = shop.Address;
                    existingShop.ContactInfo = shop.ContactInfo;
                    existingShop.Notes = shop.Notes;
                }
            }
            WriteToJsonFile(_commissionShopsFilePath, shops);
        }

        public void DeleteCommissionShop(int id)
        {
            List<CommissionShop> shops = GetAllCommissionShops();
            shops.RemoveAll(s => s.Id == id);
            WriteToJsonFile(_commissionShopsFilePath, shops);
            DeleteCommissionShopItemsByCommissionShopId(id);
        }

        public CommissionShop GetCommissionShopById(int shopId)
        {
            return GetAllCommissionShops().FirstOrDefault(s => s.Id == shopId);
        }

        // Методи для CommissionShopItem
        public List<CommissionShopItem> GetAllCommissionShopItems()
        {
            var items = ReadFromJsonFile<CommissionShopItem>(_commissionShopItemsFilePath);
            var paintings = GetAllPaintings();
            var shops = GetAllCommissionShops();

            foreach (var item in items)
            {
                item.Painting = paintings.FirstOrDefault(p => p.Id == item.PaintingId);
                item.CommissionShop = shops.FirstOrDefault(s => s.Id == item.CommissionShopId);
            }
            return items;
        }

        public void SaveCommissionShopItem(CommissionShopItem item)
        {
            List<CommissionShopItem> items = GetAllCommissionShopItems();
            if (item.Id == 0)
            {
                item.Id = GetNextId(items);
                items.Add(item);
            }
            else
            {
                var existingItem = items.FirstOrDefault(i => i.Id == item.Id);
                if (existingItem != null)
                {
                    existingItem.PaintingId = item.PaintingId;
                    existingItem.CommissionShopId = item.CommissionShopId;
                    existingItem.AskingPrice = item.AskingPrice;
                    existingItem.ListingDate = item.ListingDate;
                    existingItem.IsSold = item.IsSold;
                    existingItem.SalePrice = item.SalePrice;
                    existingItem.SaleDate = item.SaleDate;
                    existingItem.Notes = item.Notes;
                }
            }
            foreach (var i in items)
            {
                i.Painting = null;
                i.CommissionShop = null;
            }
            WriteToJsonFile(_commissionShopItemsFilePath, items);
        }

        public void DeleteCommissionShopItem(int id)
        {
            List<CommissionShopItem> items = GetAllCommissionShopItems();
            items.RemoveAll(i => i.Id == id);
            foreach (var i in items)
            {
                i.Painting = null;
                i.CommissionShop = null;
            }
            WriteToJsonFile(_commissionShopItemsFilePath, items);
        }

        public void DeleteCommissionShopItemsByCommissionShopId(int shopId)
        {
            List<CommissionShopItem> items = GetAllCommissionShopItems();
            items.RemoveAll(i => i.CommissionShopId == shopId);
            foreach (var i in items)
            {
                i.Painting = null;
                i.CommissionShop = null;
            }
            WriteToJsonFile(_commissionShopItemsFilePath, items);
        }


        // Методи для статистики
        public DatabaseStatistics GetDatabaseStatistics()
        {
            return new DatabaseStatistics
            {
                ArtistsCount = GetAllArtists().Count,
                PaintingsCount = GetAllPaintings().Count,
                CollectorsCount = GetAllCollectors().Count,
                CollectionItemsCount = GetAllPersonalCollectionItems().Count,
                AuctionsCount = GetAllAuctions().Count,
                AuctionLotsCount = GetAllAuctionLots().Count,
                CommissionShopsCount = GetAllCommissionShops().Count, // ДОДАНО
                CommissionShopItemsCount = GetAllCommissionShopItems().Count // ДОДАНО
            };
        }

        // Метод для отримання історії цін картини
        public List<PriceHistoryItem> GetPriceHistoryForPainting(int paintingId)
        {
            var allLots = GetAllAuctionLots();
            var lotsForPainting = allLots.Where(lot => lot.PaintingId == paintingId).ToList();

            var history = new List<PriceHistoryItem>();
            foreach (var lot in lotsForPainting)
            {
                history.Add(new PriceHistoryItem
                {
                    AuctionName = lot.Auction?.Name ?? "N/A",
                    AuctionDate = lot.Auction?.Date ?? DateTime.MinValue,
                    LotNumber = lot.LotNumber,
                    StartingPrice = lot.StartingPrice,
                    FinalPrice = lot.FinalPrice,
                    IsSold = lot.IsSold,
                    BuyerInfo = lot.BuyerInfo
                });
            }
            return history;
        }

        public IEnumerable<object> SearchPaintingsAndArtists(string searchTerm)
        {
            var results = new List<object>();
            searchTerm = searchTerm.ToLowerInvariant(); // Перетворює запит у нижній регістр для регістронезалежного пошуку

            var allPaintings = GetAllPaintings(); // Отримує всі картини
            var allArtists = GetAllArtists();     // Отримує всіх художників

            // Пошук за назвою картини
            var foundPaintings = allPaintings
                .Where(p => p.Title != null && p.Title.ToLowerInvariant().Contains(searchTerm))
                .Select(p => new
                {
                    Тип = "Картина",
                    Назва = p.Title,
                    Художник = p.Artist != null ? $"{p.Artist.FirstName} {p.Artist.LastName}" : "Невідомий",
                    Рік = p.Year,
                    Жанр = p.Genre
                });
            results.AddRange(foundPaintings);

            // Пошук за ім'ям або прізвищем художника
            var foundArtists = allArtists
                .Where(a => (a.FirstName != null && a.FirstName.ToLowerInvariant().Contains(searchTerm)) ||
                            (a.LastName != null && a.LastName.ToLowerInvariant().Contains(searchTerm)))
                .Select(a => new
                {
                    Тип = "Художник",
                    Ім_я = $"{a.FirstName} {a.LastName}",
                    Національність = a.Nationality,
                    Роки_життя = $"{a.BirthDate?.Year}-{a.DeathDate?.Year ?? DateTime.Now.Year}" // Додаємо роки життя
                });
            results.AddRange(foundArtists);

            return results;
        }

    } 

    public class DatabaseStatistics
    {
        public int ArtistsCount { get; set; }
        public int PaintingsCount { get; set; }
        public int CollectorsCount { get; set; }
        public int CollectionItemsCount { get; set; }
        public int AuctionsCount { get; set; }
        public int AuctionLotsCount { get; set; }
        public int CommissionShopsCount { get; set; }
        public int CommissionShopItemsCount { get; set; } 
    }
    public class PriceHistoryItem
    {
        public string AuctionName { get; set; } = string.Empty;
        public DateTime AuctionDate { get; set; }
        public int LotNumber { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal? FinalPrice { get; set; }
        public bool IsSold { get; set; }
        public string BuyerInfo { get; set; } = string.Empty;
    }
}