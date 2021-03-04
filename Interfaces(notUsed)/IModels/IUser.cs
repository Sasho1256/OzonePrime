using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<IFilm> MyFilms { get; set; }
        public List<IRole> Roles { get; set; }       
    }
}
