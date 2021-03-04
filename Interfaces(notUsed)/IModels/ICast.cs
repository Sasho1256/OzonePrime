using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface ICast
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; } //it could be either "Actor" or "Director"

        public List<IFilm> Films { get; set; }
    }
}
