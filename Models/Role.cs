using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class Role : IdentityRole<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
