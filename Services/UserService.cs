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

//@{
//    ViewData["Title"] = "Register";
//}
//< h3 > @ViewData["Title"] </ h3 >
//< form asp - controller = "UserController" asp - action = "Register" method = "post" enctype = "text/plain" >
//               Username:< br >
           
//               < input type = "text" id = "uname" name = "User_name" >< br >
//                    Password:< br >
                
//                    < input type = "password" id = "pwd" name = "Password" >< br >
//                         First Name:< br >
                     
//                         < input type = "text" id = "fname" name = "First_name" >< br >
//                              Last Name:< br >
                          
//                              < input type = "text" id = "lname" name = "Last_name" >< br >
                               
//                                   < p ></ p >
                               
//                                   < button > Create </ button >
                               
//                                   < input type = "submit" value = "Submit" />
//                                  </ form >
