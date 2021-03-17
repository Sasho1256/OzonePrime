using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class ExMessDTO
    {
        public string ExMess { get; set; }

        public ExMessDTO()
        {

        }

        public ExMessDTO(string exMess)
        {
            ExMess = exMess;
        }
    }
}
