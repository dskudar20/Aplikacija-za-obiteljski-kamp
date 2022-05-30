using Aplikacija_za_obiteljski_kamp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacija_za_obiteljski_kamp.Models
{
    public class Guest : Person
    {
        public DateTime BirthDate { get; set; }
        public int IdPlaceUnit { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public int GuestsNum { get; set; }
        public string PhoneNumber { get; set; }
        public string OwnerName { get; set; }

   
    }
}
