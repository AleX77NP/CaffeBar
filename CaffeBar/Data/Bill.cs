using CaffeBar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Models
{
    public class Bill
    {
        public int BillId { set; get; }
        public string DateAndTime { set; get; }
        public float TotalPrice { set; get; }
        public Table Table { set; get; }
        public int TableId { set; get; }
        public  virtual ICollection<BillDrink> BillDrinks { set; get; }
        public Waiter Waiter { set; get; }
        public int WaiterId { set; get; }
        
        public Bill()
        {
            BillDrinks = new List<BillDrink>();
        }

    }
}
