using CaffeBar.Data;
using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public class WaiterRepository : IWaiterRepository 
    {
        private CaffeContext context;

        public WaiterRepository(CaffeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Waiter> GetAllWaiters()
        {
            return context.Waiters.ToList();
        }
        public Waiter GetWaiterById(int WaiterId)
        {
            return context.Waiters.Find(WaiterId);
        }
        public void AddWaiter(Waiter waiter)
        {
            context.Waiters.Add(waiter);
        }
        public void RemoveWaiter(Waiter waiter)
        {
            context.Waiters.Remove(waiter);
        }
    }
}
