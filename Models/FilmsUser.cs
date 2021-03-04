using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class FilmsUser
    {
        public int FilmId { get; set; }
        public int UserId { get; set; }

        public virtual Film Film { get; set; }
        public virtual User User { get; set; }
    }
}
