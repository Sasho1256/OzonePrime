using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class Film
    {
        public string Title { get; set; }

        public int YearRelease { get; set; }

        public List<string> Directors { get; set; }

        public Film()
        {
            this.Directors = new List<string>();
        }
    }
}
