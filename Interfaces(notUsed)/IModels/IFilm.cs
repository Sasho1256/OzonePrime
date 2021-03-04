using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface IFilm
    {
        //public image Thumbnail { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ICast> Cast { get; set; }
        public List<IGenre> Genres { get; set; }
        public string Description { get; set; }
        public int YearOfRelease { get; set; }
        private static int RentExpirationDays = 15;

    }
}
