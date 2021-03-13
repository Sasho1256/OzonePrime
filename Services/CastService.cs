using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OzonePrime.Models;

namespace OzonePrime.Services
{
    public class CastService
    {
        private ozoneprimeContext database;

        public CastService(ozoneprimeContext database)
        {
            this.database = database;
        }
    }
}
