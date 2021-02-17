using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Indexes
{
    interface ICustomer
    {
        public string Username { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<IFilm> MyFilms { get; set; }

        public void Register();
        public void LogIn();
        public void LogOut();
        public void AddFilmToLibrary (IFilm film);
        public void RemoveFilmFromLibrary (IFilm film);
        
    }
}
