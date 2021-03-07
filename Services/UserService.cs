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
        private ozoneprimeContext database;

        public UserService(ozoneprimeContext database)
        {
            this.database = database;
        }
        
        public void Register(User user) 
        {
            database.Users.Add(user);
            database.SaveChanges();
        }

        internal User UserProfile()
        {
            return database.Users.FirstOrDefault(x => x.IsLoggedIn == true);
        }

        public void LogIn(User loggingUser)
        {
            foreach (var dbUser in database.Users)
            {
                dbUser.IsLoggedIn = false;
                database.Users.Update(dbUser);

                if (loggingUser.Username == dbUser.Username && loggingUser.Password == dbUser.Password)
                {
                    dbUser.IsLoggedIn = true;
                    database.Users.Update(dbUser);
                }
            }
            
            database.SaveChanges();
            return;
            
            throw new MissingMemberException("This user does not exist.");
        }

        //public void EditUser(int id, User user)
        //{
        //}

        //public void RemoveCustomer(int id)
        //{
        //}        
    }
}