using OzonePrime.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces
{
    interface IInMemoryDatabase
    {
        public IUser LoggedUser { get; set; }
        public List<ICast> Cast { get; set; }
        public List<IUser> Customers { get; set; }
        public List<IFilm> Films { get; set; }
        public List<IGenre> Genres { get; set; }
    }
}
