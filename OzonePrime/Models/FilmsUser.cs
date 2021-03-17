using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OzonePrime.Models
{
    public partial class FilmsUser
    {
        [Key, Column(Order = 0)]
        public int FilmId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public virtual Film Film { get; set; }
        public virtual User User { get; set; }
    }
}
