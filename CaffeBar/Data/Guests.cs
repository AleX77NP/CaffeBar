using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Models
{
    public class Guests
    {
        public int GuestsId { set; get; }
        public int NumOfPersons { set; get; }
        public string Reservation { set; get; }
        public string ReservationTime { set; get; }
        public string ReservationName { set; get; }
        public Table Table { set; get; }
        public int TableId { set; get; }

    }
}
