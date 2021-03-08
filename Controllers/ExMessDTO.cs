using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Controllers
{
    public class ExMessDTO
    {
        public string ExMess { get; set; }

        public ExMessDTO(string exMess)
        {
            ExMess = exMess;
        }
    }
}
