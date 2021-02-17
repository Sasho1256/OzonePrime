using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Indexes
{
    interface IGenre
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public List<IFilm> Films { get; set; }
    }
}
