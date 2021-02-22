using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Cast> Cast { get; set; }
        public List<Genre> Genres { get; set; }
        public string Description { get; set; }
        public int YearRelease { get; set; }
        private static int RentExpirationDays = 15;
        

        public List<string> Directors { get; set; } //mahni go i go napravi da raboti prez Cast a ne prez tova Directors

        public Film()
        {
            this.Directors = new List<string>();
        }
    }
}
