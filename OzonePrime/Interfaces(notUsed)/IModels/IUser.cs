using Microsoft.AspNetCore.Identity;
using OzonePrime.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface IUser
    {
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
