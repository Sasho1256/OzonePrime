using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Database
{
    public static class InMemoryDatabase
    {
        //public User LoggedUser { get; private set; }
        //public List<Cast> Cast { get; private set; }
        //public List<User> Users { get; private set; }
       //public List<Film> Films { get; private set; }
        //public List<Genre> Genres { get; private set; }
        static InMemoryDatabase()
        {
            Films = new List<Film>();
        }
        public static int Count { get; set; }
        public static List<Film> Films { get; set; }
    }
}
