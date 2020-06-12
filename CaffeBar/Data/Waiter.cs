using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Models
{
    public class Waiter
    {
        public int WaiterId { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public int Age { set; get; }
        public float Salary { set; get; }
        public string Phone { set; get; }
        public virtual ICollection<Bill> Bills { set; get; }

        public Waiter()
        {
            Bills = new List<Bill>();
        }
    }
}
