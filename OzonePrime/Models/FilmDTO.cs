using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class FilmDTO
    {
        public Film film { get; set; }
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }

        public FilmDTO()
        {

        }

        public FilmDTO(List<Director> directors, List<Genre> genres)
        {
            this.Directors = directors;
            this.Genres = genres;
        }

        public FilmDTO(Film film, List<Director> directors, List<Genre> genres)
        {
            this.film = film;
            this.Directors = directors;
            this.Genres = genres;
        }
    }
}
