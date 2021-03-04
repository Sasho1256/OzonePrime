using System;
using System.Collections.Generic;

#nullable disable

namespace OzonePrime.Models
{
    public partial class FilmsCast
    {
        public int FilmId { get; set; }
        public int CastId { get; set; }

        public virtual Cast Cast { get; set; }
        public virtual Film Film { get; set; }
    }
}
