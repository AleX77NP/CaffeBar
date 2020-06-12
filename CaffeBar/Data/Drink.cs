using CaffeBar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Models
{
    public class Drink
    {
        public int DrinkId { set; get; }
        public string Title { set; get; }
        public float Price { set; get; }
        public float TaxRate { set; get; }
        public float TotalDrink { set; get; }
        public int Available { set; get; }
        public int Count { set; get; }
        public virtual ICollection<BillDrink> BillDrinks { set; get; }

       public Drink()
        {
           BillDrinks = new List<BillDrink>();
        }
    }
}
