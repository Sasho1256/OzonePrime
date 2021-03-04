using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int? YearRelease { get; set; }
        public int ExpirationDays { get; set; }
    }
}
