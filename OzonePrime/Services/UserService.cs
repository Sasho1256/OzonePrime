using OzonePrime.Models;
using OzonePrime.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OzonePrime.Services
{
    public class UserService : IUserService
    {
        private ozoneprimeContext database;

        public UserService(ozoneprimeContext database)
        {
            this.database = database;
        }
        
        public User UserProfile()
        {
            CheckIfThereIsALoggedUser();

            return database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
        }

        public void Register(User user, ConfirmPasswordDTO confirmPassword) 
        {
            foreach (var dbUser in database.Users)
            {
                if (dbUser.IsLoggedIn == true)
                {
                    throw new AccessViolationException("You are logged in, please logout and try again!");
                }
                if (dbUser.UserName == user.UserName)
                {
                    throw new DuplicateNameException("A user with that username already exists!");
                }
            }

            if (string.IsNullOrWhiteSpace(user.UserName) || string.IsNullOrEmpty(user.UserName))
            {
                throw new ArgumentException("Invalid input for username.");
            }
            if (string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentException("Invalid input for password.");
            }
            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrEmpty(user.FirstName))
            {
                throw new ArgumentException("Invalid input for first name.");
            }
            if (string.IsNullOrWhiteSpace(confirmPassword.ConfirmPassword) || string.IsNullOrEmpty(confirmPassword.ConfirmPassword))
            {
                throw new ArgumentException("Invalid input for confirmation password.");
            }
            if (user.Password != confirmPassword.ConfirmPassword)
            {
                throw new ArgumentException("Password and confirmation password don't match.");
            }

            user.Password = Base64Encode(user.Password);

            database.Users.Add(user);
            database.SaveChanges();
        }


        public void LogIn(User loggingUser)
        {
            if (!database.Users.Any(x => x.UserName == loggingUser.UserName))
            {
                throw new MissingMemberException("Such profile doesn't exist.");
            }
            if (database.Users.Any(x => x.IsLoggedIn == true))
            {
                throw new AccessViolationException("You are logged in, please logout and try again!");
            }

            foreach (var dbUser in database.Users)
            {
                if (loggingUser.UserName == dbUser.UserName && Base64Encode(loggingUser.Password) != dbUser.Password)
                {
                    throw new InvalidOperationException("Wrong password.");
                }
                
                if (loggingUser.UserName == dbUser.UserName && Base64Encode(loggingUser.Password) == dbUser.Password)
                {
                    dbUser.IsLoggedIn = true;
                    database.Users.Update(dbUser);
                }
            }
            
            database.SaveChanges();
        }

        public void LogOut()
        {
            foreach (var dbUser in database.Users)
            {
                dbUser.IsLoggedIn = false;
                database.Users.Update(dbUser);
            }

            database.SaveChanges();
        }


        public void EditProfile(User updatedUser, ConfirmPasswordDTO confirmPassword)
        {
            User user = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            
            if (Base64Encode(confirmPassword.ConfirmPassword) != user.Password)
            {
                throw new ArgumentException("Wrong confirmation password.");
            }

            foreach (var dbUser in database.Users)
            {                
                if (dbUser.UserName == updatedUser.UserName && updatedUser.UserName != user.UserName)
                {
                    throw new DuplicateNameException("A user with that username already exists!");
                }                
            }

            if (!string.IsNullOrWhiteSpace(updatedUser.UserName) || !string.IsNullOrEmpty(updatedUser.UserName))
            {
                user.UserName = updatedUser.UserName;
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.Password) || !string.IsNullOrEmpty(updatedUser.Password))
            {
                user.Password = Base64Encode(updatedUser.Password);
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.FirstName) || !string.IsNullOrEmpty(updatedUser.FirstName))
            {
                user.FirstName = updatedUser.FirstName;
            }
            if (!string.IsNullOrWhiteSpace(updatedUser.LastName) || !string.IsNullOrEmpty(updatedUser.LastName))
            {
                user.LastName = updatedUser.LastName;
            }            

            database.SaveChanges();
        }

        public void AddFilmToMyList(string filmId)
        {
            CheckIfThereIsALoggedUser();

            User loggedUser = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            List<FilmsUser> filmsUsers = database.FilmsUsers.ToList();

            if (!filmsUsers.Exists(fu => fu.FilmId == int.Parse(filmId) && fu.UserId == loggedUser.Id))
            {
                FilmsUser filmsUser = new FilmsUser();

                filmsUser.FilmId = int.Parse(filmId);
                filmsUser.UserId = loggedUser.Id;

                database.FilmsUsers.Add(filmsUser);
            }
            
            database.SaveChanges();
        }

        public List<Film> GetMyList()
        {
            List<FilmsUser> filmsUsers = database.FilmsUsers.ToList();
            User loggedUser = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            List<Film> myList = new List<Film>();            

            foreach (var item in filmsUsers)
            {
                if (item.UserId == loggedUser.Id)
                {
                    Film film = database.Films.Where(f => f.Id == item.FilmId).First();
                    myList.Add(film);
                }
            }

            return myList;
        }

        public void RemoveFilmFromMyList(string filmId)
        {
            User loggedUser = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            Film filmToRemove = database.Films.FirstOrDefault(f => f.Id == int.Parse(filmId));
            FilmsUser filmsUserToRemove = database.FilmsUsers.FirstOrDefault(f => f.FilmId == filmToRemove.Id && f.UserId == loggedUser.Id);

            database.FilmsUsers.Remove(filmsUserToRemove);
            database.SaveChanges();
        }

        public void DeleteUser()
        {
            User userToRemove = database.Users.FirstOrDefault(u => u.IsLoggedIn == true);
            List<FilmsUser> filmsUsersToDelete = database.FilmsUsers.Where(fu => fu.UserId == userToRemove.Id).ToList();

            database.FilmsUsers.RemoveRange(filmsUsersToDelete);
            database.Users.Remove(userToRemove);
            database.SaveChanges();
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //public string Base64Decode(string base64EncodedData)
        //{
        //    var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        //    return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        //}

        public void CheckIfThereIsALoggedUser()
        {
            List<User> users = database.Users.ToList();

            if (!users.Exists(u => u.IsLoggedIn == true))
            {
                throw new AccessViolationException("You must log in first!");
            }
        }
    }
}