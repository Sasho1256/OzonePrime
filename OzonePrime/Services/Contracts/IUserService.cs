using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IUserService
    {
        /// <summary>
        /// Returns the info of the logged user.
        /// </summary>
        /// <returns></returns>
        User UserProfile();
        
        /// <summary>
        /// Adds <paramref name="user"/> to the database if its password matches <paramref name="confirmPassword"/>.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmPassword"></param>
        void Register(User user, ConfirmPasswordDTO confirmPassword);
        
        /// <summary>
        /// Sets the IsLoggedIn property of the user in the database, that corresponds to <paramref name="loggingUser"/>, to true.
        /// </summary>
        /// <param name="loggingUser"></param>
        void LogIn(User loggingUser);
        
        /// <summary>
        /// Sets the IsLoggedIn property of every user to false.
        /// </summary>
        void LogOut();

        /// <summary>
        /// Updates the info of the logged user with the info in <paramref name="updatedUser"/>, if <paramref name="confirmPassword"/> matches the password of the logged user.
        /// </summary>
        /// <param name="updatedUser"></param>
        /// <param name="confirmPassword"></param>
        void EditProfile(User updatedUser, ConfirmPasswordDTO confirmPassword);

        /// <summary>
        /// Adds <paramref name="filmId"/> and the id of the logged user together to the FilmsUsers table in the database.
        /// </summary>
        /// <param name="filmId"></param>
        void AddFilmToMyList(string filmId);

        /// <summary>
        /// Returns a list with all of the films, whose IDs and the ID of the logged user, exist together in the FilmsUsers table in the database.
        /// </summary>
        /// <returns></returns>
        List<Film> GetMyList();

        /// <summary>
        /// Removes the row with <paramref name="filmId"/> and the id of the logged user from the FilmsUsers table in the database.
        /// </summary>
        /// <param name="filmId"></param>
        void RemoveFilmFromMyList(string filmId);
        
        /// <summary>
        /// Removes the logged user from the database.
        /// </summary>
        void DeleteUser();
        
        /// <summary>
        /// Returns the encoded version of <paramref name="plainText"/>. 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string Base64Encode(string plainText);
        
        /// <summary>
        /// Throws exception if none of the user in the database are logged in.
        /// </summary>
        void CheckIfThereIsALoggedUser();
    }
}
