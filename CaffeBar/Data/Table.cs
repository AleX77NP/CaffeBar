using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Models
{
    public class Table
    {
        public int TableId { set; get; }
        public string Marking { set; get; }
        public string Title { set; get; }
        public bool Taken { set; get; }
        public Guests Guests { set; get; }
        public virtual ICollection<Bill> Bills { set; get; }

        public Table()
        {
            Bills = new List<Bill>();
        }
    }
    
}
