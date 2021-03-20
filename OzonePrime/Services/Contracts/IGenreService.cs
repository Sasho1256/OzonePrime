using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IGenreService
    {
        /// <summary>
        /// Adds <paramref name="genre"/> to the database if a genre with the same name doesn't already exist.
        /// </summary>
        /// <param name="genre"></param>
        void Create(Genre genre);

        /// <summary>
        /// Returns a list with all the genres in the database.
        /// </summary>
        /// <returns></returns>
        List<Genre> GetAll();
    }
}
