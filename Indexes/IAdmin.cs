using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Indexes
{
    interface IAdmin
    {
        public void AddFilm();
        public void AddFilmTitle(string title);
        public void AddFilmCast(List<ICast> cast);
        public void AddFilmGenre(List<IGenre> genres);
        public void AddFilmDescription(string description);

        public void EditFilmTitle(IFilm film, string newTitle);
        public void EditFilmCast(IFilm film, List<ICast> newCast);
        public void EditFilmGenre(IFilm film, List<IGenre> newGenres);
        public void EditFilmDescription(IFilm film, string newDescription);

        public void RemoveFilm(IFilm film);

        public void EditCustomerFirstName(ICustomer customer, string newFirstName);
        public void EditCustomerLastName(ICustomer customer, string newLastName);
        public void EditCustomerFilmsList(ICustomer customer, List<IFilm> newFilms);

        public void RemoveCustomer(ICustomer customer);
    }
}
