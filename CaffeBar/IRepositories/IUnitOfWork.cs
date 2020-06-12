using CaffeBar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaffeBar.IRepositories
{
    public interface IUnitOfWork
    {
        IWaiterRepository Waiters { get; }
        ITableRepository Tables { get; }
        IBillRepository Bills { get; }
        IGuestsRepository Guests { get; }
        IBillDrinkRepository BillDrinks { get; }
        IDrinkRepository Drinks { get; }

        IAuthRepository Auth { get; }
        void Complete();
    }
}
