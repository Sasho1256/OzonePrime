using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IDirectorService
    {
        /// <summary>
        /// Adds <paramref name="director"/> to the database if a director with the same names doesn't already exist. 
        /// </summary>
        /// <param name="director"></param>
        void Create(Director director);

        /// <summary>
        /// Returns a list with all the directors in the database.
        /// </summary>
        /// <returns></returns>
        List<Director> GetAll();
    }
}
