using OzonePrime.Models;
using OzonePrime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services
{
    public class DirectorService : IDirectorService
    {
        private ozoneprimeContext database;

        public DirectorService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public void Create(Director director)
        {
            List<Director> directors = database.Directors.ToList();
            if (!directors.Exists(d => d.FirstName == director.FirstName && d.LastName == director.LastName))
            {
                database.Add(director);
            }
            database.SaveChanges();
        }

        public List<Director> GetAll()
        {
            List<Director> directors = database.Directors.ToList();
            return directors;
        }
    }
}
