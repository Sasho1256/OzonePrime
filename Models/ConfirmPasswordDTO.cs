using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonePrime.Models
{
    public class ConfirmPasswordDTO
    {
        public ConfirmPasswordDTO()
        {

        }
        public ConfirmPasswordDTO(string confirmPassword)
        {
            this.ConfirmPassword = confirmPassword;
        }

        public string ConfirmPassword { get; set; }
    }
}
