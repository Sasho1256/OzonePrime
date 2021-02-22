using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class Genre
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public List<Film> Films { get; private set; }
    }
}
