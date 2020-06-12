using CaffeBar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.Repositories
{
    public interface IWaiterRepository
    {
        IEnumerable<Waiter> GetAllWaiters();
        Waiter GetWaiterById(int WaiterId);
        void AddWaiter(Waiter waiter);
        void RemoveWaiter(Waiter waiter);
    }
}
