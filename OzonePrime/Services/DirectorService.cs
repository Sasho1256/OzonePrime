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
        private OzoneprimeContext database;

        public DirectorService(OzoneprimeContext database)
        {
            this.database = database;
        }

        public void Create(Director director)
        {
            if (string.IsNullOrEmpty(director.FirstName) || string.IsNullOrWhiteSpace(director.FirstName))
            {
                throw new ArgumentException("Incorrect input for first name.");
            }
            if (string.IsNullOrEmpty(director.LastName) || string.IsNullOrWhiteSpace(director.LastName))
            {
                throw new ArgumentException("Incorrect input for last name.");
            }
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
