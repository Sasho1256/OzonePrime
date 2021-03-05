using Microsoft.AspNetCore.Mvc;
using OzonePrime.Database;
using OzonePrime.Interfaces.IControllers;
using OzonePrime.Interfaces.IModels;
using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services
{
    public class UserService
    {
        public ozoneprimeContext database;

        public UserService(ozoneprimeContext database)
        {
            this.database = database;
        }

        public void Register(string username, string password, string firstName, string lastName) 
        {
            User user = new User();

            user.Username = username;
            user.Password = password;
            user.FirstName = firstName;
            user.LastName = lastName;

            database.Users.Add(user);
            database.SaveChanges();
        }

        //public void LogIn()
        //{

        //}

        //public void EditUser(int id, User user)
        //{
        //    User userToEdit = database.Users.FirstOrDefault(x => x.Id == id);

        //    userToEdit = user;
        //}

        //public void RemoveCustomer(int id)
        //{
                  
        //}        
    }
}
