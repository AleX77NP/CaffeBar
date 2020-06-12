using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Data
{
    public class BillDrink
    {
        public int BillId { get; set; }
        public int DrinkId { get; set; }
        public int DrinkCount {get; set;}
        public Bill Bill { get; set; }
        public Drink Drink { get; set; }
        public int BillDrinkId {get; set;}
    }
}
