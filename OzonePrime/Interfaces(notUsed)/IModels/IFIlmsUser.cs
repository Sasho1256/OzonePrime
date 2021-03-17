using OzonePrime.Interfaces.IModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces_notUsed_.IModels
{
    interface IFIlmsUser
    {
        [Key, Column(Order = 0)]
        public int FilmId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }

        public IFilm Film { get; set; }
        public IUser User { get; set; }
    }
}
