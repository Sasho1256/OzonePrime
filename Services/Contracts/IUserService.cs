using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Services.Contracts
{
    interface IUserService
    {
        User UserProfile();
        void Register(User user, ConfirmPasswordDTO confirmPassword);
        void LogIn(User loggingUser);
        void LogOut();
        void EditProfile(User updatedUser, ConfirmPasswordDTO confirmPassword);
        void AddFilmToMyList(string filmId);
        List<Film> GetMyList();
        void RemoveFilmFromMyList(string filmId);
        void DeleteUser();
        string Base64Encode(string plainText);
        string Base64Decode(string base64EncodedData);
        void CheckIfThereIsALoggedUser();
    }
}
