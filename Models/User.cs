﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class User : IdentityUser<int>
    {
        public int Id { get; set; }
        //public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
