using System;

namespace Сursova.Models
{
    public class Painting
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public Artist Artist { get; set; } // Навігаційна властивість для художника
        public int? Year { get; set; } // Рік може бути невідомий
        public DateTime? CreationDate { get; set; } // Дата створення картини
        public string Genre { get; set; } = string.Empty; // Будемо використовувати для Жанру
        public string Technique { get; set; } = string.Empty;
        public string Dimensions { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty; // Шлях до файлу зображення

        public string ArtistFullName => Artist?.FullName ?? "Невідомий художник";
    }
}