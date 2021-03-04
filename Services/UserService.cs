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
    public class UserService
    {
        private ozoneprimeContext database;

        public UserService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public void Register() 
        {
            
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
