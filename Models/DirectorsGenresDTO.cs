using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class DirectorsGenresDTO
    {
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }

        public DirectorsGenresDTO()
        {

        }

        public DirectorsGenresDTO(List<Director> directors, List<Genre> genres)
        {
            this.Directors = directors;
            this.Genres = genres;
        }
    }
}
