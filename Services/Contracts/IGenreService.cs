using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IGenreService
    {
        void Create(Genre genre);
        List<Genre> GetAll();
    }
}
