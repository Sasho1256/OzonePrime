using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Indexes
{
    interface IInMemoryDatabase
    {
        public List<ICast> Cast { get; set; }
        public List<ICustomer> Customers { get; set; }
        public List<IFilm> Films { get; set; }
        public List<IGenre> Genres { get; set; }
    }
}
