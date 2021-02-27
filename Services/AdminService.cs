using OzonePrime.Database;
using OzonePrime.Interfaces.IControllers;
using OzonePrime.Interfaces.IModels;
using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services
{
    public class AdminService
    {
        private InMemoryDatabase database;

        public AdminService(InMemoryDatabase database)
        {
            this.database = database;
        }

        public void AddFilm(Film film)
        {
            database.Films.Add(film);
        }

        public void EditFilm(int id, Film film)
        {
            Film filmToEdit = database.Films.FirstOrDefault(x => x.Id == id);
            filmToEdit = film;
        }

        public void RemoveFilm(int id)
        {
            Film filmToRemove = database.Films.FirstOrDefault(x => x.Id == id);
            database.Films.Remove(filmToRemove);
        }

        public void EditUser(int id, User user)
        {
            User userToEdit = database.Users.FirstOrDefault(x => x.Id == id);
            userToEdit = user;
        }        

        public void RemoveCustomer(int id)
        {
            User userToRemove = database.Users.FirstOrDefault(x => x.Id == id);
            database.Users.Remove(userToRemove);
        }        
    }
}
