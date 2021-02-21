using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Interfaces.IModels
{
    interface IRole
    {
        public int Id { get; set; }
        public string Name { get; set; } //admin or customer
    }
}
