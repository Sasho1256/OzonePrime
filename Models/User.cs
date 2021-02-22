using OzonePrime.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public string Password { get; private set; }
        public List<Film> MyFilms { get; private set; }
        public List<Role> Roles { get; private set; }
    }
}
