using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Сursova.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;

        public List<string> Styles { get; set; } = new List<string>();
        public string PhotoPath { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        public bool IsAlive => DeathDate == null; 
    }
}
