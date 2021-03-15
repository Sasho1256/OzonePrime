﻿using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Database
{
    public class InMemoryDatabase
    {
        public User LoggedUser { get; private set; }
        public List<Director> Cast { get; private set; }
        public List<User> Users { get; private set; }
        public List<Genre> Genres { get; private set; }
        public List<Film> Films { get; private set; }
        public int Count { get; set; }

        public InMemoryDatabase()
        {
            Films = new List<Film>();
        }
    }
}
