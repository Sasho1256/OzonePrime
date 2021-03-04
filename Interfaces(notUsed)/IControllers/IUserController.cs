using OzonePrime.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IControllers
{
    interface IUserController
    {
        public void Register();
        public void LogIn();
        public void LogOut();
        public void AddFilmToLibrary(IFilm film);
        public void RemoveFilmFromLibrary(IFilm film);
    }
}
