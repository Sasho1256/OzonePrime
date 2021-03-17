using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class Director
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Film> Films { get; set; }
    }
}
