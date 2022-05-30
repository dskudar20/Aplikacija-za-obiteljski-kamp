using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija_za_obiteljski_kamp.Models
{
    public class Owner : Person
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CheckPassword(string password)
        {
            return Password == password;
        }
        public override string ToString()
        {
            return FirstName + " " + LastName;
        }

    }

}
