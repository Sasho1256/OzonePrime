using OzonePrime.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IControllers
{
    interface IAdminController
    {
        public void AddFilm(IFilm film);
        
        public void EditFilmTitle(int id, IFilm film);        

        public void RemoveFilm(int id);

        
        public void EditCustomer(int id, IUser customer);

        public void RemoveCustomer(int id);
    }
}
