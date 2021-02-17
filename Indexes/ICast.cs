using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Indexes
{
    interface ICast
    {
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; } //it could be either "Actor" or "Director"

        public List<IFilm> Films { get; set; }
    }
}
